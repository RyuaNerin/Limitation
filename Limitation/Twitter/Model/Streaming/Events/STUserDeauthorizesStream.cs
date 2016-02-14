﻿using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // access_revoked
    [DataContract]
	[DebuggerDisplay("access_revoked")]
    internal class STUserDeauthorizesStream : STEvents
    {
        [DataMember(Name = "source")]
        public User DeauthorizingUser { get; set; }

        [DataMember(Name = "target")]
        public User AppOwner { get; set; }

        [DataMember(Name = "target_object")]
        public object TargetObject { get; set; }
    }
}