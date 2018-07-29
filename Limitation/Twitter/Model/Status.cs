using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Twitter.BaseModel
{
    [JsonObject]
    [DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
	internal class Status : TwitterObject<Status>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("in_reply_to_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long InReplyToStatusId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }

        [JsonProperty("extended_entities")]
        public StatusEntities ExtendedEntities { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        [JsonProperty("extended_tweet")]
        public ExtendedTweet ExtendedTweet { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }

        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("is_quote_status")]
        public long IsQuoteStatus { get; set; }

        [JsonProperty("quoted_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long QuotedStatusId { get; set; }
        
        [JsonProperty("quoted_status")]
        public Status QuotedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        ///////////////////////////////////////////////////////

        private static Regex m_sourceRegex = new Regex(@"^<a href=""([^""]+)""(?: rel=""nofollow"")?>(.+)<\/a>$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private string m_source;
        [JsonProperty("source")]
        public string Source
        {
            get => this.m_source;
            set
            {
                var m = m_sourceRegex.Match(value);
                this.m_source = Uri.UnescapeDataString(string.Intern(m.Groups[2].Value));
                this.SourceUri = Uri.UnescapeDataString(string.Intern(m.Groups[1].Value));
                if (this.SourceUri.StartsWith("//"))
                    this.SourceUri = "http:" + this.SourceUri;

                this.m_source = string.Intern(this.m_source);
                this.SourceUri = string.Intern(this.SourceUri);

                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Source"));
            }
        }

        public string SourceUri { get; private set; }

        //////////////////////////////////////////////////

        [JsonProperty("current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }

        //////////////////////////////////////////////////
        
        public int IsDeleted { get; set; }
        
        public int IsRetweetedByMe { get; set; }

        public User DisplayUser => this.RetweetedStatus != null ? this.RetweetedStatus.User : this.User;

        private string m_displayTextOneLine;
        [DependsOn("Text", "ExtendedTweet")]
        public string DisplayTextOneLine => this.m_displayTextOneLine ?? (this.m_displayTextOneLine = this.DisplayText.Replace("\r", "").Replace("\n", ""));

        private string m_displayText;
        [DependsOn("Text", "ExtendedTweet")]
        public string DisplayText => this.m_displayText ?? (this.m_displayText = this.GetDisplayText());

        private string m_dateTimeAndVia;
        [DependsOn("CreatedAt", "Source")]
        public string DateTimeAndVia => this.m_dateTimeAndVia ?? (this.m_dateTimeAndVia = $"{this.CreatedAt.ToString()} / {this.Source}"); //"yyyy-MM-dd HH:mm:ss d"

        [DependsOn("ExtendedTweet")]
        public bool HasMedia
        {
            get
            {
                var stat = (this.RetweetedStatus ?? this);
                return (stat.ExtendedEntities ?? stat.Entities)?.Media?.Length > 0;
            }
        }

        [DependsOn("ExtendedTweet")]
        public string[] Images
        {
            get
            {
                var stat = (this.RetweetedStatus ?? this);
                return (stat.ExtendedEntities ?? stat.Entities)?.Media?.Select(e => e.MediaUrl).ToArray();
            }
        }
    }

    [JsonObject]
    public class CurrentUserRetweet
    {
        [JsonProperty("id_str")]
        public string Id { get; set; }
    }

    [JsonObject]
    public class ExtendedTweet
    {
        [JsonProperty("full_text")]
        public string FullText { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }
    }

    [JsonObject]
    public class StatusEntities
    {
        [JsonProperty("urls")]
        public UrlEntity[] Urls { get; set; }

        [JsonProperty("user_mentions")]
        public MentionEntity[] Mentions { get; set; }

        [JsonProperty("hashtags")]
        public HashTagEntity[] HashTags { get; set; }

        [JsonProperty("media")]
        public Media[] Media { get; set; }
    }

    [JsonObject]
    public class UrlEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }
    }

    [JsonObject]
    public class MentionEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    [JsonObject]
    public class HashTagEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    [JsonObject]
    public class Media
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }
}
