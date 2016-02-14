using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // list_updated
    [DataContract]
	[DebuggerDisplay("list_updated")]
    internal class STListUpdated : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}
