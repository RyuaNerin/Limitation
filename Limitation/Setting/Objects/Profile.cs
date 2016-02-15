using Limitation.Twitter.OAuth;
using Limitation.Twitter.Streaming.Model;

namespace Limitation.Setting.Objects
{
    internal class Profile
    {
        [SettingAttr]
        public string UserToken { get; set; }

        [SettingAttr]
        public string UserSecret { get; set; }

        [SettingAttr]
        public string Filter { get; set; }

        public int m_userid;
        public int UserId
        {
            get
            {
                if (this.m_userid == 0)
                {
                    var str = UserToken;
                    str = str.Substring(0, str.IndexOf('-'));

                    this.m_userid = int.Parse(str);
                }

                return this.m_userid;
            }
        }

        private OAuth m_oauth;
        public OAuth OAuth
        {
            get
            {
                return this.m_oauth ?? (this.m_oauth = new OAuth(App.AppToken, App.AppSecret));
            }
        }

        private TwitterStreaming m_streaming;
        public TwitterStreaming Streaming
        {
            get
            {
                return this.m_streaming ?? (this.m_streaming = new TwitterStreaming(this));
            }
        }
    }
}
