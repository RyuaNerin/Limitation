using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model
{
    [DataContract]
	[DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
	internal class Status : BaseModel<Status>
    {
        [DataMember(Name = "id")]
        public override long Id { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "recipient")]
        public User Recipient { get; set; }

        [DataMember(Name = "sender")]
        public User Sender { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "entities")]
        public StatusEntities Entities { get; set; }

        [DataMember(Name = "retweeted_status")]
        public Status RetweetedStatus { get; set; }

        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }

        [DataMember(Name = "retweeted")]
        public bool Retweeted { get; set; }

        [DataMember(Name = "current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }
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
