using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model
{
    [DataContract]
	[DebuggerDisplay("List")]
	internal class List : BaseModel<User>
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        
        [DataMember(Name = "slug")]
        public string Slug { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "mode")]
        public string mode { get; set; }

        [DataMember(Name = "following")]
        public bool Following { get; set; }
        
        [DataMember(Name = "member_count", IsRequired = true)]
        public int MemberCount { get; set; }

        [DataMember(Name = "subscriber_count")]
        public int SubscriberCount { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
        
        [DataMember(Name = "id", IsRequired = true)]
        public override long Id { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }
	}
}
