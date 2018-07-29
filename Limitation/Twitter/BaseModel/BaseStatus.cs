using System;
using System.ComponentModel;
using System.Diagnostics;
using Limitation.Twitter.Objects;
using Newtonsoft.Json;

namespace Limitation.Twitter.BaseModel
{
    [JsonObject]
    [DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
	internal abstract class BaseStatus : TwitterObject<BaseStatus>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("in_reply_to_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long InReplyToStatusId { get; set; }

        [JsonProperty("user")]
        public UserObject User { get; set; }

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
        public BaseStatus RetweetedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("is_quote_status")]
        public long IsQuoteStatus { get; set; }

        [JsonProperty("quoted_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long QuotedStatusId { get; set; }
        
        [JsonProperty("quoted_status")]
        public BaseStatus QuotedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("source")]
        public string Source { get; set; }

        //////////////////////////////////////////////////

        [JsonProperty("current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }
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
