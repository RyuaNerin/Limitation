using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Setting.Objects
{
    [JsonObject]
    [AddINotifyPropertyChangedInterface]
    internal class WindowOption
    {
        [JsonProperty("x")]
        public double Left { get; set; }
        
        [JsonProperty("y")]
        public double Top { get; set; }

        [JsonProperty("w")]
        public double Width { get; set; } = 400;

        [JsonProperty("h")]
        public double Height { get; set; } = 500;
    }
}
