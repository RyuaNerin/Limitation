using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class Design
    {
        private FontOption m_fontSize;
        [DataMember(Name = "fontsize")]
        public FontOption FontSize
        {
            get { return m_fontSize ?? (m_fontSize = new FontOption()); }
            set { if (value != null) m_fontSize = value; }
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

    [DataContract]
    internal class FontOption
    {
        [DataMember(Name = "font")]
        public string Font { get; set; }

        [DataMember(Name = "timeline_size")]
        [DefaultValue(11)]
        public int TimeLine { get; set; }

        [DataMember(Name = "detail_size")]
        [DefaultValue(11)]
        public int Detail { get; set; }
    }
}
