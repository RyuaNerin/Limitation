﻿using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // quoted_tweet
    [DataContract]
	[DebuggerDisplay("quoted_tweet")]
    internal class STQuotedTweet : STEvents
    {
        [DataMember(Name = "source")]
        public User QuotingUser { get; set; }

        [DataMember(Name = "target")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target_object")]
        public Status Tweet { get; set; }
    }
}
