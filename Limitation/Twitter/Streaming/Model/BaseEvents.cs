using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("event event={Event}")]
    internal class BaseEvents : TwitterStreamingMessage
    {
        [DataMember(Name = "event", IsRequired = true)]
        public string Event { get; set; }

        [DataMember(Name = "created_at", IsRequired = true)]
        public DateTime CreatedAt { get; set; }
    }
}
