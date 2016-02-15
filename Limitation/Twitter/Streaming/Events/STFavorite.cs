using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // favorite
    [DataContract]
	[DebuggerDisplay("favorite")]
    internal class STFavorite : STEvents
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
