using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // unfollow
    [DataContract]
	[DebuggerDisplay("unfollow")]
    internal class Unfollow : BaseEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User FollwedUser { get; set; }
    }
}
