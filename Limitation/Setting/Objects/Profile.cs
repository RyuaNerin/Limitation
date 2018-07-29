using System.Collections.Generic;
using System.ComponentModel;
using Limitation.Twitter.OAuth;
using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Setting.Objects
{
    [JsonObject]
    [AddINotifyPropertyChangedInterface]
    internal class Profile
    {
        [JsonProperty("token")]
        public string UserToken { get; set; }

        [JsonProperty("secret")]
        public string UserSecret { get; set; }

        [JsonProperty("highlight", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DoNotNotify]
        public List<Rule> Highlight { get; } = new List<Rule>();

        [JsonProperty("filter", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DoNotNotify]
        public List<Rule> Filter { get; } = new List<Rule>();

        public int m_userid;
        [JsonIgnore]
        [DoNotNotify]
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
        [DoNotNotify]
        [JsonIgnore]
        public OAuth OAuth => this.m_oauth ?? (this.m_oauth = new OAuth(App.AppToken, App.AppSecret, this.UserToken, this.UserSecret));
    }
    
    [JsonObject]
    internal class Rule
    {
        [JsonProperty("name")]
        public string RuleName { get; set; }

        [JsonProperty("rules", DefaultValueHandling = DefaultValueHandling.Populate)]
        public List<DetailRule> Detail { get; } = new List<DetailRule>();
    }

    [JsonObject]
    internal class DetailRule
    {
        [JsonProperty("return")]
        public bool Return { get; set; }

        [JsonProperty("rule_type")]
        public RuleTypes RuleType { get; set; }

        [JsonProperty("value_type")]
        public ValueTypes ValueType { get; set; }

        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("include_mention")]
        [DefaultValue(false)]
        public bool IncludeMention { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public enum RuleTypes
    {
        Text,
        UserName,
        ScreenName,
        UserId,
        HashTag,
        Via,
    }

    public enum ValueTypes
    {
        Regular,
        WildCard,
        Regex,
    }
}
