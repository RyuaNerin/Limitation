using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // unblock
    [DataContract]
	[DebuggerDisplay("unblock")]
    internal class Unblock : BaseEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User UnblockedUser { get; set; }
    }
}
