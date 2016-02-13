using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("event event={Event}")]
    internal class EventsBase
    {
        [DataMember(Name = "event")]
        public string Event { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime Event { get; set; }
    }
}
