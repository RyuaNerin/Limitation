using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("status_withheld id={StatusWithheld.Id}, user_id={StatusWithheld.UserId}")]
    internal class StatusWithheld : TwitterStreamingMessage
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "withheld_in_countries")]
        public string[] WithheldInCountries { get; set; }
    }
}
