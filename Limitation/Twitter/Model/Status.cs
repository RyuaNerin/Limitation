using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Limitation.Twitter.Model
{
    [JsonObject]
	[DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
	internal class Status : TwitterObject<Status>
    {

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("in_reply_to_status_id")]
        public long InReplyToStatusId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("extended_tweet")]
        public ExtendedTweet ExtendedTweet { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }

        [JsonProperty("extended_entities")]
        public StatusEntities ExtendedEntities { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        ///////////////////////////////////////////////////////

        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }

        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("is_quote_status")]
        public long IsQuoteStatus { get; set; }

        [JsonProperty("quoted_status_id")]
        public long QuotedStatusId { get; set; }
        
        [JsonProperty("quoted_status")]
        public Status QuotedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        private static Regex m_sourceRegex = new Regex("^<a href=\"([^\"]+)\"(:? rel=\"\\\"nofollow\\\"\")?>(.+)<\\/a>$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private string m_source;
        [JsonProperty("source")]
        public string Source
        {
            get { return m_source; }
            set
            {
                var m = m_sourceRegex.Match(value);
                this.m_source = Uri.UnescapeDataString(string.Intern(m.Groups[2].Value));
                this.SourceUri = Uri.UnescapeDataString(string.Intern(m.Groups[1].Value));
                if (this.SourceUri.StartsWith("//")) this.SourceUri = "http:" + this.SourceUri;
            }
        }

        public string SourceUri { get; private set; }

        //////////////////////////////////////////////////

        [JsonProperty("current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }

        //////////////////////////////////////////////////
        
        public int IsDeleted { get; set; }
        
        public int IsRetweetedByMe { get; set; }
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
