using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("delete id={Delete.Id}, user_id={Delete.UserId}")]
    internal class DeleteEvent
    {
        [DataMember(Name = "delete")]
        public Delete Delete { get; set; }
                    
        [DataContract]
        public class Delete
        {
            [DataMember(Name = "id")]
            public long Id { get; set; }

            [DataMember(Name = "user_id")]
            public long UserId { get; set; }
        }
    }
}
