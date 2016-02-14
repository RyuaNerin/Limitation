﻿using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // list_user_subscribed
    [DataContract]
	[DebuggerDisplay("list_user_subscribed")]
    internal class STListUserSubscribed : STEvents
    {
        /// <summary>
        /// Current User / Subscribing User
        /// </summary>
        [DataMember(Name = "source")]
        public User Source { get; set; }

        /// <summary>
        /// List Owner / Current User
        /// </summary>
        [DataMember(Name = "target")]
        public User Target { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}