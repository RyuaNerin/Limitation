using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
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
