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

        private bool m_defaultProfile;
        [DataMember(Name = "default_profile")]
        public bool DefaultProfile
        {
            get { return m_defaultProfile; }
            set { m_defaultProfile = value; OnPropertyChanged(); }
        }

        private bool m_defaultProfileImage;
        [DataMember(Name = "default_profile_image")]
        public bool DefaultProfileImage
        {
            get { return m_defaultProfileImage; }
            set { m_defaultProfileImage = value; OnPropertyChanged(); }
        }

        private string m_Description;
        [DataMember(Name = "description")]
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; OnPropertyChanged(); }
        }

        private UserEntities m_entities;
        [DataMember(Name = "entities")]
        public UserEntities Entities
        {
            get { return m_entities; }
            set { m_entities = value; OnPropertyChanged(); }
        }

        private int m_favouritesCount;
        [DataMember(Name = "favourites_count")]
        public int FavouritesCount
        {
            get { return m_favouritesCount; }
            set { m_favouritesCount = value; OnPropertyChanged(); }
        }

        private bool m_followRequestSent;
        [DataMember(Name = "follow_request_sent")]
        public bool FollowRequestSent
        {
            get { return m_followRequestSent; }
            set { m_followRequestSent = value; OnPropertyChanged(); }
        }

        private bool m_following;
        [DataMember(Name = "following")]
        public bool Following
        {
            get { return m_following; }
            set { m_following = value; OnPropertyChanged(); }
        }

        private int m_followersCount;
        [DataMember(Name = "followers_count")]
        public int FollowersCount
        {
            get { return m_followersCount; }
            set { m_followersCount = value; OnPropertyChanged(); }
        }

        private int m_friendsCount;
        [DataMember(Name = "friends_count")]
        public int FriendsCount
        {
            get { return m_friendsCount; }
            set { m_friendsCount = value; OnPropertyChanged(); }
        }

        private bool m_geoEnabled;
        [DataMember(Name = "geo_enabled")]
        public bool GeoEnabled
        {
            get { return m_geoEnabled; }
            set { m_geoEnabled = value; OnPropertyChanged(); }
        }

        [DataMember(Name = "id", IsRequired = true)]
        public override long Id { get; set; }

        private string m_lang;
        [DataMember(Name = "lang")]
        public string Lang
        {
            get { return m_lang; }
            set { m_lang = value; OnPropertyChanged(); }
        }

        private int m_listedCount;
        [DataMember(Name = "listed_count")]
        public int ListedCount
        {
            get { return m_listedCount; }
            set { m_listedCount = value; OnPropertyChanged(); }
        }

        private string m_location;
        [DataMember(Name = "location")]
        public string Location
        {
            get { return m_location; }
            set { m_location = value; OnPropertyChanged(); }
        }

        private string m_name;
        [DataMember(Name = "name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; OnPropertyChanged(); }
        }

        private string m_profileBannerUrl;
        [DataMember(Name = "profile_banner_url")]
        public string ProfileBannerUrl
        {
            get { return m_profileBannerUrl; }
            set { m_profileBannerUrl = value; OnPropertyChanged(); }
        }

        private string m_profileImageUrl;
        [DataMember(Name = "profile_image_url_http")]
        public string ProfileImageUrl
        {
            get { return m_profileImageUrl; }
            set { m_profileImageUrl = value; OnPropertyChanged(); }
        }

        private bool m_protected;
        [DataMember(Name = "protected")]
        public bool Protected
        {
            get { return m_protected; }
            set { m_protected = value; OnPropertyChanged(); }
        }
        
        private string m_screenName;
        [DataMember(Name = "screen_name", IsRequired = true)]
        public string ScreenName
        {
            get { return m_screenName; }
            set { m_screenName = value; OnPropertyChanged(); }
        }

        private Status m_status;
        [DataMember(Name = "status")]
        public Status Status
        {
            get { return m_status; }
            set { m_status = value.IsInterned(); OnPropertyChanged(); }
        }

        private int m_statusesCount;
        [DataMember(Name = "statuses_count")]
        public int StatusesCount
        {
            get { return m_statusesCount; }
            set { m_statusesCount = value; OnPropertyChanged(); }
        }

        private int m_timeZone;
        [DataMember(Name = "time_zone")]
        public int TimeZone
        {
            get { return m_timeZone; }
            set { m_timeZone = value; OnPropertyChanged(); }
        }

        private string m_url;
        [DataMember(Name = "url")]
        public string Url
        {
            get { return m_url; }
            set { m_url = value; OnPropertyChanged(); }
        }

        private int m_utcOffset;
        [DataMember(Name = "utc_offset")]
        public int UtcOffset
        {
            get { return m_utcOffset; }
            set { m_utcOffset = value; OnPropertyChanged(); }
        }

        private bool m_verified;
        [DataMember(Name = "verified")]
        public bool Verified
        {
            get { return m_verified; }
            set { m_verified = value; OnPropertyChanged(); }
        }
        
        private string m_withheldInCountries;
        [DataMember(Name = "withheld_in_countries")]
        public string WithheldInCountries
        {
            get { return m_withheldInCountries; }
            set { m_withheldInCountries = value; OnPropertyChanged(); }
        }
        
        private string m_withheldScope;
        [DataMember(Name = "withheld_scope")]
        public string WithheldScope
        {
            get { return m_withheldScope; }
            set { m_withheldScope = value; OnPropertyChanged(); }
        }
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
