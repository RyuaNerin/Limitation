using System.Windows;
using Limitation.Helpers;
using Limitation.Setting.Objects;
using Limitation.Twitter.OAuth;
using Limitation.Windows.Models;

namespace Limitation.Windows
{
    internal partial class MainWindow : Window
	{
        public static MainWindow Instance { get; private set; }

		public MainWindow()
		{
            Instance = this;

			InitializeComponent();


            this.DataContext = this.Model;
		}

        public MainWindowModel Model { get; } = new MainWindowModel();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Model.Options.Profiles.Count == 0)
            {
                var oauth = new OAuth(App.AppToken, App.AppSecret);
                var rt = oauth.RequestToken();
                if (rt != null)
                {
                    Explorer.OpenUri("https://api.twitter.com/oauth/authorize?force_login=true&oauth_token=" + rt.Token);

                    var wnd = new PinWindow
                    {
                        Owner = this
                    };

                    if (wnd.ShowDialog() ?? false)
                    {
                        oauth = new OAuth(App.AppToken, App.AppSecret, rt.Token, rt.Secret);
                        var ut = oauth.AccessToken(wnd.PinText);

                        if (ut != null)
                        {
                            var profile = new Profile
                            {
                                UserToken = ut.Token,
                                UserSecret = ut.Secret,
                            };

                            this.Model.Options.Profiles.Add(profile);
                        }
                    }
                }
            }
            
            if (this.Model.Options.Profiles.Count > 0)
            {
                this.Model.SetProfile(this.Model.Options.Profiles[0]);
                MessageBox.Show(this, this.Title, "프로필 설정됨");
            }
        }

        private void LoadTweet_Click(object sender, RoutedEventArgs e)
        {
            this.Model.CurrentTimeline?.Update();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Model.SetTimeline(this.Model.Home);
        }

        private void Mention_Click(object sender, RoutedEventArgs e)
        {
            this.Model.SetTimeline(this.Model.Mention);
        }
    }
}
