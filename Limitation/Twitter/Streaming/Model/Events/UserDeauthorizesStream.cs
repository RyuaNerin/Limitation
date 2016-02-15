using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // access_revoked
    [DataContract]
	[DebuggerDisplay("access_revoked")]
    internal class UserDeauthorizesStream : BaseEvents
    {
        [DataMember(Name = "source")]
        public User DeauthorizingUser { get; set; }

        [DataMember(Name = "target")]
        public User AppOwner { get; set; }

        [DataMember(Name = "target_object")]
        public object TargetObject { get; set; }
    }
}
