using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // follow
    [DataContract]
	[DebuggerDisplay("follow")]
    internal class STFollow : STEvents
    {
        /// <summary>
        /// Current User / Following User
        /// </summary>
        [DataMember(Name = "source")]
        public User Source { get; set; }

        /// <summary>
        /// Followed User / Current User
        /// </summary>
        [DataMember(Name = "target")]
        public User Target { get; set; }
    }
}
