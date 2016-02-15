using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // quoted_tweet
    [DataContract]
	[DebuggerDisplay("quoted_tweet")]
    internal class QuotedTweet : BaseEvents
    {
        [DataMember(Name = "source")]
        public User QuotingUser { get; set; }

        [DataMember(Name = "target")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target_object")]
        public Status Tweet { get; set; }
    }
}
