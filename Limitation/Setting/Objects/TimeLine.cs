using System.ComponentModel;
using System.Runtime.Serialization;
using Limitation.Twitter.TimeLine;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class TimeLine
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "use_streaming")]
        [DefaultValue(true)]
        public bool UseStreaming { get; set; }

        [DataMember(Name = "user_id")]
        public long user_id { get; set; }

        [DataMember(Name = "type")]
        public TimeLineTypes TimeLineType { get; set; }

        [DataMember(Name = "show_badge")]
        [DefaultValue(true)]
        public bool ShowBadge { get; set; }

        [DataMember(Name = "sound")]
        [DefaultValue(false)]
        public bool Sound { get; set; }

        [DataMember(Name = "notification")]
        [DefaultValue(true)]
        public bool Notification { get; set; }
    }
}
