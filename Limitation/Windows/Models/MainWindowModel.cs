using Limitation.Setting;
using Limitation.Setting.Objects;
using Limitation.Twitter.TimeLine;
using PropertyChanged;

namespace Limitation.Windows.Models
{
    [AddINotifyPropertyChangedInterface]
    internal class MainWindowModel
    {
        public Options Options => Options.Instance;

        public Profile Profile { get; private set; }

        [DoNotNotify]
        public BaseTimeLine Home { get; private set; }
        
        [DoNotNotify]
        public BaseTimeLine Mention { get; private set; }

        [DoNotNotify]
        public BaseTimeLine DirectMessage { get; private set; }

        public BaseTimeLine CurrentTimeline { get; private set; }

        public void SetProfile(Profile profile)
        {
            this.Profile = profile;

            this.Home = new HomeTimeLine(profile);
            this.Mention = new MentionTimeLine(profile);

            this.CurrentTimeline = this.Home;
        }

        public void SetTimeline(BaseTimeLine timeline)
        {
            if (timeline == null) return;

            this.CurrentTimeline = timeline;
        }
    }
}
