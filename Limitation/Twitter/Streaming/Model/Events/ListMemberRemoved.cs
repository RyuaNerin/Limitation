using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // list_member_removed
    [DataContract]
	[DebuggerDisplay("list_member_removed")]
    internal class ListMemberRemoved : BaseEvents
    {
        /// <summary>
        /// Current User / Removing User
        /// </summary>
        [DataMember(Name = "source")]
        public User Source { get; set; }

        /// <summary>
        /// Removed User / Current User
        /// </summary>
        [DataMember(Name = "target")]
        public User Target { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}
