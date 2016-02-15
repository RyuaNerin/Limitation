using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming
{
    [DataContract]
	[DebuggerDisplay("user_withheld user_id={UserWithheld.UserId}")]
    internal class STUserWithheld
    {
        [DataMember(Name = "user_withheld")]
        public UserWithheldObject UserWithheld { get; set; }
                    
        [DataContract]
        public class UserWithheldObject
        {
            [DataMember(Name = "user_id")]
            public long UserId { get; set; }

            [DataMember(Name = "withheld_in_countries")]
            public string[] WithheldInCountries { get; set; }
        }
    }
}
