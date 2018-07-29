using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Limitation.Twitter.BaseModel;

namespace Limitation.Twitter.Objects
{
    internal class StatusObject : BaseStatus
    {
        public string m_via;
        public string m_viaUrl;

        public string Via    => this.m_via    ?? ParseSource().via;
        public string ViaUrl => this.m_viaUrl ?? ParseSource().url;

        private static readonly Regex SourceParser = new Regex(@"^<a href=""([^""]+)""(?: rel=""nofollow"")?>(.+)<\/a>$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private (string via, string url) ParseSource()
        {
            var m = SourceParser.Match(this.Source);

            this.m_via    = Uri.UnescapeDataString(string.Intern(m.Groups[2].Value));
            this.m_viaUrl = Uri.UnescapeDataString(string.Intern(m.Groups[1].Value));

            if (this.m_viaUrl.StartsWith("//"))
                this.m_viaUrl = "http:" + this.m_viaUrl;

            this.m_via = string.Intern(this.m_via);
            this.m_viaUrl = string.Intern(this.m_viaUrl);

            return (this.m_via, this.m_viaUrl);
        }

        public int IsDeleted { get; set; }

        public int IsRetweetedByMe { get; set; }

        public UserObject DisplayUser => this.RetweetedStatus != null ? this.RetweetedStatus.User : this.User;

        private string m_displayTextOneLine;
        public string DisplayTextOneLine => this.m_displayTextOneLine ?? (this.m_displayTextOneLine = this.DisplayText.Replace("\r", "").Replace("\n", ""));

        private string m_displayText;
        public string DisplayText => this.m_displayText ?? (this.m_displayText = GetDisplayText(this));

        private string m_dateTimeAndVia;
        public string DateTimeAndVia => this.m_dateTimeAndVia ?? (this.m_dateTimeAndVia = $"{this.CreatedAt.ToString()} / {this.Source}"); //"yyyy-MM-dd HH:mm:ss d"

        public bool HasMedia
        {
            get
            {
                var stat = (this.RetweetedStatus ?? this);
                return (stat.ExtendedEntities ?? stat.Entities)?.Media?.Length > 0;
            }
        }

        public string[] Images
        {
            get
            {
                var stat = (this.RetweetedStatus ?? this);
                return (stat.ExtendedEntities ?? stat.Entities)?.Media?.Select(e => e.MediaUrl).ToArray();
            }
        }
        
        public static string GetDisplayText(BaseStatus status)
        {
            string text;
            StatusEntities enti;

            if (status.RetweetedStatus != null)
                status = status.RetweetedStatus;

            if (status.Truncated && status.ExtendedTweet != null)
            {
                text = status.ExtendedTweet.FullText;
                enti = status.ExtendedTweet.Entities;
            }
            else
            {
                text = status.Text;
                enti = status.ExtendedEntities;
                if (enti == null)
                    enti = status.Entities;
            }

            if (enti != null)
            {
                var withMedia = enti.Media != null && enti.Media.Length > 0;
                var withUrls = enti.Urls != null && enti.Urls.Length > 0;

                if (withMedia || withUrls)
                {
                    var sb = new StringBuilder(text.Length * 2);

                    var lst = new List<(int start, int end, string text)>();

                    if (withMedia)
                        foreach (var item in enti.Media)
                            if (lst.FindIndex(e => e.start == item.Indices[0]) == -1)
                                lst.Add((item.Indices[0], item.Indices[1], item.DisplayUrl));

                    if (withUrls)
                        foreach (var item in enti.Urls)
                            if (lst.FindIndex(e => e.start == item.Indices[0]) == -1)
                                lst.Add((item.Indices[0], item.Indices[1], item.DisplayUrl));

                    lst.Sort((a, b) => a.start.CompareTo(b.start));

                    int lastIndice = 0;

                    for (int i = 0; i < lst.Count; ++i)
                    {
                        sb.Append(text.Substring(lastIndice, lst[i].start));
                        sb.Append(lst[i].text);

                        lastIndice = lst[i].end;
                    }

                    sb.Append(text.Substring(lst[lst.Count - 1].end));

                    return sb.ToString();
                }
            }

            return text;
        }
    }
}
