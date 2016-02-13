using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    // user_update
    [DataContract]
	[DebuggerDisplay("event event={Event}")]
    internal class UserUpdateEvents : EventsBase
    {
        [DataMember(Name = "source")]
        public User Source { get; set; }

        [DataMember(Name = "target")]
        public User Target { get; set; }
    }
}
