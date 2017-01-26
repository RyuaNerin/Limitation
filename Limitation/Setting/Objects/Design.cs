using System.ComponentModel;
using System.Runtime.Serialization;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class Design
    {
        private FontOption m_fontSize = new FontOption();
        [DataMember(Name = "fontsize", EmitDefaultValue = false)]
        public FontOption FontSize
        {
            get { return m_fontSize; }
        }

        [DataMember(Name = "line_spacing")]
        [DefaultValue(2)]
        public int LineSpacing { get; set; }

        [DataMember(Name = "square_avatar")]
        [DefaultValue(true)]
        public bool SquareAvatar { get; set; }

        [DataMember(Name = "view_tweets_limit")]
        [DefaultValue(1000)]
        public int ViewTweetsLimit { get; set; }

        [DataMember(Name = "show_thumbnail")]
        [DefaultValue(true)]
        public bool ShowThumbnail { get; set; }

        [DataMember(Name = "thumbnail_size")]
        [DefaultValue(60)]
        public int ThumbnailSize { get; set; }
        
        [DataMember(Name = "data_format")]
        [DefaultValue(DataFormats.Mixed)]
        public DataFormats DataFormat { get; set; }

        [DataMember(Name = "display_name")]
        [DefaultValue(DisplayNames.Mixed)]
        public DisplayNames DisplayName { get; set; }

        [DataMember(Name = "tweet_height")]
        [DefaultValue(40)]
        public int TweetHeight { get; set; }

        [DataMember(Name = "profile_size")]
        [DefaultValue(32)]
        public int ProfileSize { get; set; }
    }

    [DataContract]
    internal class FontOption
    {
        [DataMember(Name = "font")]
        public string Font { get; set; }

        [DataMember(Name = "display_name_size")]
        [DefaultValue(11)]
        public int NameSize { get; set; }

        [DataMember(Name = "body_size")]
        [DefaultValue(11)]
        public int BodySize { get; set; }
    }
    
    [DataContract]
    public enum DataFormats
    {
        [EnumMember(Value = "relative")]
        Relative,
        [EnumMember(Value = "absoulte")]
        Absolute,
        [EnumMember(Value = "mixed")]
        Mixed
    }


    [DataContract]
    public enum DisplayNames
    {
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "screen_name")]
        ScreenName,
        [EnumMember(Value = "mixed")]
        Mixed,
    }
}
