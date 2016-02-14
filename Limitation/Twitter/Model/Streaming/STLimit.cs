using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("limit track={Limit.Track}")]
    internal class STLimit
    {
        [DataMember(Name = "limit")]
        public LimitObject Limit { get; set; }
                    
        [DataContract]
        public class LimitObject
        {
            [DataMember(Name = "track")]
            public long Track { get; set; }
        }
    }
}
