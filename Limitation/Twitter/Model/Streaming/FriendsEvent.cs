using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("friends")]
    internal class FriendsEvent
    {
        [DataMember(Name = "friends")]
        public long[] Friends { get; set; }
    }
    [DataContract]
	[DebuggerDisplay("friends")]
    internal class FriendsStrEvent
    {
        [DataMember(Name = "friends")]
        public string[] Friends { get; set; }
    }
}
