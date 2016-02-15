using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // block
    [DataContract]
    [DebuggerDisplay("block")]
    internal class Block : BaseEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target")]
        public User BlockedUser { get; set; }
    }
}
