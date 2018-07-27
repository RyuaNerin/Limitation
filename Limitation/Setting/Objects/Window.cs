using System.ComponentModel;
using Newtonsoft.Json;

namespace Limitation.Setting.Objects
{
    [JsonObject]
    internal class Window : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("x")]
        public double Left { get; set; }
        
        [JsonProperty("y")]
        public double Top { get; set; }
        
        [JsonProperty("w")]
        public double Width { get; set; }
        
        [JsonProperty("h")]
        public double Height { get; set; }
    }
}
