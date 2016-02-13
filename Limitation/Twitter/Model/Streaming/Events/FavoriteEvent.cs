using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // access_revoked
    [DataContract]
	[DebuggerDisplay("event event={Event}")]
    internal class UnblockEvent : EventsBase
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User UnblockedUser { get; set; }
    }
}
