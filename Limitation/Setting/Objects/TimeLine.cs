using System.ComponentModel;
using System.Runtime.Serialization;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class TimeLine
    {
        [DataMember(Name = "use_streaming")]
        [DefaultValue(true)]
        public bool UseStreaming { get; set; }

    }
}
