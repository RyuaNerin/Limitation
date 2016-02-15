using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("user_withheld user_id={UserWithheld.UserId}")]
    internal class UserWithheld : TwitterStreamingMessage
    {
        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        [DataMember(Name = "withheld_in_countries")]
        public string[] WithheldInCountries { get; set; }
    }
}
