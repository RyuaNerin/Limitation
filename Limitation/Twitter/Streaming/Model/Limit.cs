using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("limit track={Limit.Track}")]
    internal class Limit : TwitterStreamingMessage
    {
        [DataMember(Name = "track")]
        public long Track { get; set; }
    }
}
