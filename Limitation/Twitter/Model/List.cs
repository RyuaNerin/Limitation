using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model
{
    [DataContract]
	[DebuggerDisplay("List")]
	internal class List : BaseModel<List>
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        
        private string m_slug;
        [DataMember(Name = "slug")]
        public string Slug
        {
            get { return m_slug; }
            set { m_slug = value; OnPropertyChanged(); }
        }
        
        private string m_name;
        [DataMember(Name = "name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; OnPropertyChanged(); }
        }

        public string m_fullName;
        [DataMember(Name = "full_name")]
        public string FullName
        {
            get { return m_fullName; }
            set { m_fullName = value; OnPropertyChanged(); }
        }

        private string m_mode;
        [DataMember(Name = "mode")]
        public string Mode
        {
            get { return m_mode; }
            set { m_mode = value; OnPropertyChanged(); }
        }

        private bool m_following;
        [DataMember(Name = "following")]
        public bool Following
        {
            get { return m_following; }
            set { m_following = value; OnPropertyChanged(); }
        }
        
        private int m_memberCount;
        [DataMember(Name = "member_count", IsRequired = true)]
        public int MemberCount
        {
            get { return m_memberCount; }
            set { m_memberCount = value; OnPropertyChanged(); }
        }

        private int m_subscriberCount;
        [DataMember(Name = "subscriber_count")]
        public int SubscriberCount
        {
            get { return m_subscriberCount; }
            set { m_subscriberCount = value; OnPropertyChanged(); }
        }

        [DataMember(Name = "user")]
        public User User { get; set; }
        
        [DataMember(Name = "id", IsRequired = true)]
        public override long Id { get; set; }

        private string m_uri;
        [DataMember(Name = "uri")]
        public string Uri
        {
            get { return m_uri; }
            set { m_uri = value; OnPropertyChanged(); }
        }
	}
}
