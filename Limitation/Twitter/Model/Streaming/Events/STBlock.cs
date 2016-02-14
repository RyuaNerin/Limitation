using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // block
    [DataContract]
	[DebuggerDisplay("block")]
    internal class STBlock : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User BlockedUser { get; set; }
    }
}
