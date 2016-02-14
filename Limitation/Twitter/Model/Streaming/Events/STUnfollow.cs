using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
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
