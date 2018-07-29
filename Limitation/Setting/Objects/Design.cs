using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Setting.Objects
{
    [AddINotifyPropertyChangedInterface]
    internal class DesignOption
    {   
        [JsonProperty("font")]
        public string Font { get; set; } = "맑은 고딕";

        [JsonProperty("display_name_size")]
        public int FontNameSize { get; set; } = 11;

        [JsonProperty("body_size")]
        public int FontBodySize { get; set; } = 12;

        [JsonProperty("line_spacing")]
        public int LineSpacing { get; set; } = 2;

        [JsonProperty("square_avatar")]
        public bool SquareAvatar { get; set; } = false;

        [JsonProperty("view_tweets_limit")]
        public int ViewTweetsLimit { get; set; } = 1000;

        [JsonProperty("expaned_tweet")]
        public bool ExpanedTweet { get; set; } = false;

        [JsonProperty("show_thumbnail")]
        public bool ShowThumbnail { get; set; } = true;

        [JsonProperty("thumbnail_size")]
        public int ThumbnailSize { get; set; } = 120;

        /* TO-DO
        [JsonProperty("data_format")]
        public DataFormats DataFormat { get; set; } = DataFormats.Mixed;
        */

        [JsonProperty("display_name")]
        public DisplayNames DisplayName { get; set; } = DisplayNames.Mixed;

        [JsonProperty("tweet_height")]
        public int TweetHeight { get; set; } = 48;

        [JsonProperty("profile_size")]
        public int ProfileSize { get; set; } = 48;
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
