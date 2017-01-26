using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Streaming.Model
{
    [DataContract]
	[DebuggerDisplay("warning code={Delete.Id}, message={Delete.Message}, PersentFull={Warning.PercentFull}")]
    internal class Warning : TwitterStreamingMessage
    {
        [DataMember(Name = "code", IsRequired = true)]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }

    // Code = FALLING_BEHIND
    [DataContract]
    [DebuggerDisplay("warning code={Delete.Id}, message={Delete.Message}, PercentFull={Warning.PercentFull}")]
    internal class StallWarning : Warning
    {
        [DataMember(Name = "percent_full")]
        public int PercentFull { get; set; }
    }

    // Code = FOLLOWS_OVER_LIMIT
    [DataContract]
    [DebuggerDisplay("warning code={Delete.Id}, message={Delete.Message}, UserId={Warning.UserId}")]
    internal class TooManyFollowsWarning : Warning
    {
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }
    }
}
