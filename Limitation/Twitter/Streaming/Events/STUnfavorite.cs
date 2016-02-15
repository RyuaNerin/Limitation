using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // unfavorite
    [DataContract]
	[DebuggerDisplay("unfavorite")]
    internal class STUnfavorite : STEvents
    {
        /// <summary>
        /// Current User / Liking User
        /// </summary>
        [DataMember(Name = "source")]
        public User Source { get; set; }

        /// <summary>
        /// Tweet Author / Current User
        /// </summary>
        [DataMember(Name = "target")]
        public User Target { get; set; }

        [DataMember(Name = "target_object")]
        public Status Tweet { get; set; }
    }
}
