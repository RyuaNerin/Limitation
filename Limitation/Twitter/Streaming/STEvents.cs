using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming
{
    [DataContract]
	[DebuggerDisplay("event event={Event}")]
    internal class STEvents
    {
        [DataMember(Name = "event")]
        public string Event { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
