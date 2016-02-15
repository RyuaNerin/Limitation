using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("delete id={Delete.Id}, user_id={Delete.UserId}")]
    internal class Delete : TwitterStreamingMessage
    {
        [DataMember(Name = "status")]
        public StatusObject Status { get; set; }

        [DataContract]
        public class StatusObject
        {
            [DataMember(Name = "id")]
            public long Id { get; set; }

            [DataMember(Name = "user_id")]
            public long UserId { get; set; }
        }
    }
}
