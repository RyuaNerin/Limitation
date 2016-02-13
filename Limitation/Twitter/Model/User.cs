using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model
{
    [Serializable]
    [DataContract]
	[DebuggerDisplay("User {Id} - @{ScreenName}")]
	internal class User : TwModel<User>
    {
        private string m_screenname;
        private string m_name;
        private string m_profileImage;

        [DataMember(Name = "id")]
        public override long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; OnPropertyChanged(Name); }
        }

        [DataMember(Name = "screen_name")]
        public string ScreenName
        {
            get { return m_screenname; }
            set { m_screenname = value; OnPropertyChanged(ScreenName); }
        }

        [DataMember(Name = "profile_image_url_https")]
        public string ProfileImageUrl
        {
            get { return m_profileImage; }
            set { m_profileImage = value; OnPropertyChanged(ProfileImageUrl); }
        }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "verified")]
        public bool Verified { get; set; }

        [DataMember(Name = "location")]
        public string Location { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "statuses_count")]
        public int Tweets { get; set; }

        [DataMember(Name = "friends_count")]
        public int Friends { get; set; }

        [DataMember(Name = "followers_count")]
        public int Followers { get; set; }

        [DataMember(Name = "entities")]
        public UserEntities Entities { get; set; }
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
