using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("scrub_geo user_id={ScrubGeo.UserId}, up_to_status_id={ScrubGeo.UpToStatusId}")]
    internal class ScrubGeoEvent
    {
        [DataMember(Name = "scrub_geo")]
        public ScrubGeo ScrubGeo { get; set; }

        [DataContract]
        public class ScrubGeo
        {
            [DataMember(Name = "user_id")]
            public long UserId { get; set; }

            [DataMember(Name = "up_to_status_id")]
            public long UpToStatusId { get; set; }
        }
    }
}
