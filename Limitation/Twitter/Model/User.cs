using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model
{
    [DataContract]
	[DebuggerDisplay("User {Id} - @{ScreenName}")]
	internal class User : BaseModel<User>
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "default_profile")]
        public bool DefaultProfile { get; set; }

        [DataMember(Name = "default_profile_image")]
        public bool DefaultProfileImage { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "entities")]
        public UserEntities Entities { get; set; }

        [DataMember(Name = "favourites_count")]
        public int FavouritesCount { get; set; }

        [DataMember(Name = "follow_request_sent")]
        public bool FollowRequestSent { get; set; }

        [DataMember(Name = "following")]
        public bool? Following { get; set; }

        [DataMember(Name = "followers_count")]
        public int FollowersCount { get; set; }

        [DataMember(Name = "friends_count")]
        public int FriendsCount { get; set; }

        [DataMember(Name = "geo_enabled")]
        public int GeoEnabled { get; set; }

        [DataMember(Name = "id")]
        public override long Id { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }

        [DataMember(Name = "listed_count")]
        public int ListedCount { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        private string m_name;
        [DataMember(Name = "name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; OnPropertyChanged(); }
        }

        private string m_profile_banner_url;
        [DataMember(Name = "profile_banner_url")]
        public string ProfileBannerUrl
        {
            get { return m_profile_banner_url; }
            set { m_profile_banner_url = value; OnPropertyChanged(); }
        }

        private string m_profile_image_url_https;
        [DataMember(Name = "profile_image_url_https")]
        public string ProfileImageUrl
        {
            get { return m_profile_image_url_https; }
            set { m_profile_image_url_https = value; OnPropertyChanged(); }
        }

        [DataMember(Name = "protected")]
        public bool Protected { get; set; }
        
        private string m_screenname;
        [DataMember(Name = "screen_name")]
        public string ScreenName
        {
            get { return m_screenname; }
            set { m_screenname = value; OnPropertyChanged(); }
        }

        [DataMember(Name = "status")]
        public Status Status { get; set; }

        [DataMember(Name = "statuses_count")]
        public int StatusesCount { get; set; }

        [DataMember(Name = "time_zone")]
        public int TimeZone { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "utc_offset")]
        public int UtcOffset { get; set; }

        [DataMember(Name = "verified")]
        public bool Verified { get; set; }

        [DataMember(Name = "withheld_in_countries")]
        public string WithheldInCountries { get; set; }
        
        [DataMember(Name = "withheld_scope")]
        public string WithheldScope { get; set; }
	}

    [DataContract]
    public class UserEntities
    {
        [DataMember(Name = "url")]
        public UserUrlEntity Url { get; set; }
    }

    [DataContract]
    public class UserUrlEntity
    {
        [DataMember(Name = "urls")]
        public UrlEntity[] Urls { get; set; }
    }
}
