using System.Diagnostics;
using System.Runtime.Serialization;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Streaming.Model
{
    // user_update
    [DataContract]
	[DebuggerDisplay("user_update")]
    internal class UserUpdate : BaseEvents
    {
        [DataMember(Name = "source")]
        public User CurrentUser { get; set; }
    }
}
