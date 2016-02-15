using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // unblock
    [DataContract]
	[DebuggerDisplay("unblock")]
    internal class STUnblock : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User UnblockedUser { get; set; }
    }
}
