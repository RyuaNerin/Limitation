using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // list_destroyed
    [DataContract]
	[DebuggerDisplay("list_destroyed")]
    internal class STListDestroyed : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }

        [DataMember(Name = "target_object")]
        public List List { get; set; }
    }
}
