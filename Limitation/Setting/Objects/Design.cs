using System.ComponentModel;
using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Setting.Objects
{
    [JsonObject]
    internal class Design : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("fontsize", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DoNotNotify]
        public FontOption FontSize { get; } = new FontOption();

        [JsonProperty("line_spacing")]
        public int LineSpacing { get; set; } = 2;

        [JsonProperty("square_avatar")]
        public bool SquareAvatar { get; set; } = true;

        [JsonProperty("view_tweets_limit")]
        public int ViewTweetsLimit { get; set; } = 1000;

        [JsonProperty("show_thumbnail")]
        public bool ShowThumbnail { get; set; } = true;

        [JsonProperty("thumbnail_size")]
        public int ThumbnailSize { get; set; } = 60;

        [JsonProperty("data_format")]
        public DataFormats DataFormat { get; set; } = DataFormats.Mixed;

        [JsonProperty("display_name")]
        public DisplayNames DisplayName { get; set; } = DisplayNames.Mixed;

        [JsonProperty("tweet_height")]
        public int TweetHeight { get; set; } = 40;

        [JsonProperty("profile_size")]
        public int ProfileSize { get; set; } = 32;
    }

    [JsonObject]
    internal class FontOption : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("font")]
        public string Font { get; set; } = "맑은 고딕";

        [JsonProperty("display_name_size")]
        public int NameSize { get; set; } = 11;

        [JsonProperty("body_size")]
        public int BodySize { get; set; } = 11;
    }
    
    public enum DataFormats
    {
        Relative,
        Absolute,
        Mixed
    }

    
    public enum DisplayNames
    {
        Name,
        ScreenName,
        Mixed,
    }
}
