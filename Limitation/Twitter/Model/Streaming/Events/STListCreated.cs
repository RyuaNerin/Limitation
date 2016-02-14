using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // list_created
    [DataContract]
	[DebuggerDisplay("list_created")]
    internal class STListCreated : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}
