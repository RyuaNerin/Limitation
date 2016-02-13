using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("user_withheld user_id={UserWithheld.UserId}")]
    internal class UserWithheldEvent
    {
        [DataMember(Name = "user_withheld")]
        public UserWithheld UserWithheld { get; set; }
                    
        [DataContract]
        public class UserWithheld
        {
            [DataMember(Name = "user_id")]
            public long UserId { get; set; }

            [DataMember(Name = "withheld_in_countries")]
            public string[] WithheldInCountries { get; set; }
        }
    }
}
