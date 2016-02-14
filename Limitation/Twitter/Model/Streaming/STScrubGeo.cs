using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("scrub_geo user_id={ScrubGeo.UserId}, up_to_status_id={ScrubGeo.UpToStatusId}")]
    internal class STScrubGeo
    {
        [DataMember(Name = "scrub_geo")]
        public ScrubGeoObject ScrubGeo { get; set; }

        [DataContract]
        public class ScrubGeoObject
        {
            [DataMember(Name = "user_id")]
            public long UserId { get; set; }

            [DataMember(Name = "up_to_status_id")]
            public long UpToStatusId { get; set; }
        }
    }
}
