using System.Collections.Generic;
using System.Runtime.Serialization;
using Limitation.Twitter.OAuth;
using Limitation.Twitter.Streaming;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class Profile
    {
        [DataMember(Name = "token")]
        public string UserToken { get; set; }

        [DataMember(Name = "secret")]
        public string UserSecret { get; set; }

        private List<Rule> m_highlight;
        [DataMember(Name = "highlight")]
        public List<Rule> Highlight
        {
            get { return m_highlight ?? (m_highlight = new List<Rule>()); }
            set { if (value != null) this.m_highlight = value; }
        }

        private List<Rule> m_filter;
        [DataMember(Name = "filter")]
        public List<Rule> Filter
        {
            get { return m_filter ?? (m_filter = new List<Rule>()); }
            set { if (value != null) this.m_filter = value; }
        }

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
    
    [DataContract]
    internal class Rule
    {
        [DataMember(Name = "name")]
        public string RuleName { get; set; }

        private List<DetailRule> m_detail;
        [DataMember(Name = "rules")]
        public List<DetailRule> Detail
        {
            get { return m_detail ?? (m_detail = new List<DetailRule>()); }
            set { if (value != null) m_detail = value; }
        }
    }

    [DataContract]
    internal class DetailRule
    {
        [DataMember(Name = "return")]
        public bool Return { get; set; }

        [DataMember(Name = "text")]
        public RuleTypes RuleType { get; set; }

        [DataMember(Name = "value_type")]
        public ValueTypes ValueType { get; set; }

        [DataMember(Name = "match")]
        public bool Match { get; set; }

        [DataMember(Name = "mention")]
        public bool Mention { get; set; }
        
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

    [DataContract]
    public enum RuleTypes
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "user_name")]
        UserName,
        [EnumMember(Value = "screen_name")]
        ScreenName,
        [EnumMember(Value = "user_id")]
        UserId,
        [EnumMember(Value = "hashtag")]
        HashTag,
        [EnumMember(Value = "via")]
        Via,
    }

    [DataContract]
    public enum ValueTypes
    {
        [EnumMember(Value = "regular")]
        Regular,
        [EnumMember(Value = "Wildcard")]
        WildCard,
        [EnumMember(Value = "regex")]
        Regex,
    }
}
