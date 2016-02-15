using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming
{
    // user_update
    [DataContract]
	[DebuggerDisplay("user_update")]
    internal class STUserUpdate : STEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }
    }
}
