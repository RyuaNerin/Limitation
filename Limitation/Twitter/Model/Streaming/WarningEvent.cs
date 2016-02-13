using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("warning code={Delete.Id}, message={Delete.Message}, PersentFull={Warning.PercentFull}")]
    internal class WarningEvent
    {
        [DataMember(Name = "warning")]
        public Warning Warning { get; set; }
                    
        [DataContract]
        public class Warning
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "message")]
            public string Message { get; set; }
            
            // Code = FALLING_BEHIND
            [DataMember(Name = "percent_full")]
            public int PercentFull { get; set; }
            
            // Code = FOLLOWS_OVER_LIMIT
            [DataMember(Name = "user_id")]
            public int UserId { get; set; }
        }
    }
}
