using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // list_member_added
    [DataContract]
	[DebuggerDisplay("list_member_added")]
    internal class STListMemberAdded : STEvents
    {
        /// <summary>
        /// Current User / Adding User
        /// </summary>
        [DataMember(Name = "source")]
        public User Source { get; set; }

        /// <summary>
        /// Added User / Current User
        /// </summary>
        [DataMember(Name = "target")]
        public User Target { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}
