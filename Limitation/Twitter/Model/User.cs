using System;
using System.Diagnostics;
using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Twitter.BaseModel
{
    [JsonObject]
    [AddINotifyPropertyChangedInterface]
    [DebuggerDisplay("User {Id} - @{ScreenName}")]
	internal class User : TwitterObject<User>
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("entities")]
        public UserEntities Entities { get; set; }
        
        [JsonProperty("follow_request_sent")]
        public bool FollowRequestSent { get; set; }
        
        [JsonProperty("following")]
        public bool Following { get; set; }
        
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }
        
        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("id")]
        public override long Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_banner_url")]
        public string ProfileBannerUrl { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        
        [JsonProperty("protected")]
        public bool Protected { get; set; }
        
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
        
        [JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        //////////////////////////////////////////////////

        [DependsOn("ScreenName", "Name")]
        public string MixedName => $"{this.Name} (@{this.ScreenName})";
    }

    [JsonObject]
    public class UserEntities
    {
        [JsonProperty("url")]
        public UserUrlEntity Url { get; set; }
    }

    [JsonObject]
    public class UserUrlEntity
    {
        [JsonProperty("urls")]
        public UrlEntity[] Urls { get; set; }
    }
}
