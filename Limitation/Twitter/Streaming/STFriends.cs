using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming
{
    [DataContract]
    [DebuggerDisplay("friends")]
    internal class STFriends
    {
        [DataMember(Name = "friends")]
        public long[] Friends { get; set; }
    }
}
