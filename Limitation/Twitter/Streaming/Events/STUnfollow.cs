using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // unfollow
    [DataContract]
	[DebuggerDisplay("unfollow")]
    internal class STUnfollow : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User FollwedUser { get; set; }
    }
}
