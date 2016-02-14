using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // list_user_unsubscribed
    [DataContract]
	[DebuggerDisplay("list_user_unsubscribed")]
    internal class STListUserUnsubscribed : STEvents
    {
        /// <summary>
        /// Current User / Unsubscribing User
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
