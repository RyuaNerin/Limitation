using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("delete id={Delete.Id}, user_id={Delete.UserId}")]
    internal class STDelete
    {
        [DataMember(Name = "delete")]
        public DeleteObject Delete { get; set; }
                    
        [DataContract]
        public class DeleteObject
        {
            [DataMember(Name = "id")]
            public long Id { get; set; }

            [DataMember(Name = "user_id")]
            public long UserId { get; set; }
        }
    }
}
