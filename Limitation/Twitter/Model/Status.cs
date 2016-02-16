using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Limitation.Twitter.Model
{
    [DataContract]
	[DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
	internal class Status : BaseModel<Status>
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "entities")]
        public StatusEntities Entities { get; set; }

        private int m_favoriteCount;
        [DataMember(Name = "favorite_count")]
        public int FavoriteCount
        {
            get { return m_favoriteCount; }
            set { m_favoriteCount = value; OnPropertyChanged(); }
        }

        private bool m_favorited;
        [DataMember(Name = "favorited")]
        public bool Favorited
        {
            get { return m_favorited; }
            set { m_favorited = value; OnPropertyChanged(); }
        }
        
        /// <summary>
        /// none, low, medium
        /// </summary>
        [DataMember(Name = "filter_level")]
        public FilterLevels FilterLevel { get; set; }

        [DataContract]
        public enum FilterLevels
        {
            [EnumMember(Value = "none")]    None,
            [EnumMember(Value = "low")]     Low,
            [EnumMember(Value = "medium")]  Medium
        }
        
        [DataMember(Name = "id", IsRequired = true)]
        public override long Id { get; set; }

        [DataMember(Name = "in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        [DataMember(Name = "in_reply_to_status_id")]
        public long InReplyToStatusId { get; set; }

        [DataMember(Name = "in_reply_to_user_id")]
        public long InReplyToUserId { get; set; }

        [DataMember(Name = "possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [DataMember(Name = "quoted_status_id")]
        public long QuotedStatusId { get; set; }

        [DataMember(Name = "quoted_status")]
        public Status QuotedStatus { get; set; }

        private int m_retweetCount;
        [DataMember(Name = "retweet_count")]
        public int RetweetCount
        {
            get { return m_retweetCount; }
            set { m_retweetCount = value; OnPropertyChanged(); }
        }

        private bool m_retweeted;
        [DataMember(Name = "retweeted")]
        public bool Retweeted
        {
            get { return m_retweeted; }
            set { m_retweeted = value; OnPropertyChanged(); }
        }

        [DataMember(Name = "retweeted_status")]
        public Status RetweetedStatus { get; set; }

        private static Regex m_sourceRegex = new Regex("^<a href=\"([^\"]+)\"(:? rel=\"\\\"nofollow\\\"\")?>(.+)<\\/a>$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private string m_source;
        [DataMember(Name = "source")]
        public string Source
        {
            get { return m_source; }
            set
            {
                var m = m_sourceRegex.Match(value);
                this.m_source = string.Intern(m.Groups[2].Value);
                this.SourceUri = string.Intern(m.Groups[1].Value);
                if (this.SourceUri.StartsWith("//")) this.SourceUri = "http:" + this.SourceUri;
            }
        }

        public string SourceUri { get; set; }

        [DataMember(Name = "text", IsRequired = true)]
        public string Text { get; set; }
    
        [DataMember(Name = "user", IsRequired = true)]
        public User User { get; set; }

        //////////////////////////////////////////////////

        [DataMember(Name = "recipient")]
        public User Recipient { get; set; }

        [DataMember(Name = "sender")]
        public User Sender { get; set; }

        [DataMember(Name = "current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }

        //////////////////////////////////////////////////

        private int m_isDeleted;
        public int IsDeleted
        {
            get { return m_isDeleted; }
            set { m_isDeleted = value; OnPropertyChanged(); }
        }

        private int m_isRetweetedByMe;
        public int IsRetweetedByMe
        {
            get { return m_isRetweetedByMe; }
            set { m_isRetweetedByMe = value; OnPropertyChanged(); }
        }
	}

    [DataContract]
    public class CurrentUserRetweet
    {
        [DataMember(Name = "id_str")]
        public string Id;
    }

    [DataContract]
    public class StatusEntities
    {
        [DataMember(Name = "urls")]
        public UrlEntity[] Urls { get; set; }

        [DataMember(Name = "user_mentions")]
        public MentionEntity[] Mentions { get; set; }

        [DataMember(Name = "hashtags")]
        public HashTagEntity[] HashTags { get; set; }

        [DataMember(Name = "media")]
        public Media[] Media { get; set; }
    }

    [DataContract]
    public class UrlEntity
    {
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }

        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; set; }
    }

    [DataContract]
    public class MentionEntity
    {
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }

        [DataMember(Name = "id_str")]
        public string Id { get; set; }

        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class HashTagEntity
    {
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }

    [DataContract]
    public class Media
    {
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; set; }

        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; set; }

        [DataMember(Name = "media_url")]
        public string MediaUrl { get; set; }
    }
}
