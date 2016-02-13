using System.Diagnostics;
using System.Runtime.Serialization;

namespace Limitation.Twitter.Model.Streaming
{
    [DataContract]
	[DebuggerDisplay("disconnect Code={Disconnect.Code}, StreamName={Disconnect.StreamName}, Reason={Disconnect.Reason}")]
    internal class DisconnectEvent
    {
        [DataMember(Name = "disconnect")]
        public Disconnect Disconnect { get; set; }
                    
        [DataContract]
        public class Disconnect
        {
            [DataMember(Name = "code")]
            public DisconnectCodes Code { get; set; }

            [DataMember(Name = "stream_name")]
            public string StreamName { get; set; }

            [DataMember(Name = "reason")]
            public string Reason { get; set; }
        }

        [DataContract]
        public enum DisconnectCodes
        {
            /// <summary>The feed was shutdown (possibly a machine restart)</summary>
            [EnumMember]
            Shutdown = 1,
            
            /// <summary>The same endpoint was connected too many times.</summary>
            [EnumMember]
            DuplicateStream = 2,
            
            /// <summary>Control streams was used to close a stream (applies to sitestreams).</summary>
            [EnumMember]
            ControlRequest = 3,
            
            /// <summary>The client was reading too slowly and was disconnected by the server.</summary>
            [EnumMember]
            Stall = 4,
            
            /// <summary>The client appeared to have initiated a disconnect.</summary>
            [EnumMember]
            Normal = 5,
            
            /// <summary>An oauth token was revoked for a user (applies to site and userstreams).</summary>
            [EnumMember]
            TokenRevoked = 6,
            
            /// <summary>The same credentials were used to connect a new stream and the oldest was disconnected.</summary>
            [EnumMember]
            AdminLogout = 7,
            
            /// <summary>Reserved for internal use. Will not be delivered to external clients.</summary>
            [EnumMember]
            Unnamed = 8,
            
            /// <summary>The stream connected with a negative count parameter and was disconnected after all backfill was delivered.</summary>
            [EnumMember]
            MaxMessageLimit = 9,
            
            /// <summary>An internal issue disconnected the stream.</summary>
            [EnumMember]
            StreamException = 10,
            
            /// <summary>An internal issue disconnected the stream.</summary>
            [EnumMember]
            BrokerStall = 11,
            
            /// <summary>The host the stream was connected to became overloaded and streams were disconnected to balance load. Reconnect as usual.</summary>
            [EnumMember]
            ShedLoad = 12,
        }
    }
}
