using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("limit track={Limit.Track}")]
    internal class LimitEvent
    {
        [DataMember(Name = "limit")]
        public Limit Limit { get; set; }
                    
        [DataContract]
        public class Limit
        {
            [DataMember(Name = "track")]
            public long Track { get; set; }
        }
    }
}
