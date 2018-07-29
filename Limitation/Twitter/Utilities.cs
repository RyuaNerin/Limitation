using System;
using System.Collections.Generic;
using System.Text;
using Limitation.Setting.Objects;
using Limitation.Twitter.BaseModel;
using Newtonsoft.Json;

namespace Limitation.Twitter
{
    internal static class Utilities
    {
        private static readonly JsonSerializerSettings JsonSetting;

        static Utilities()
        {
            JsonSetting = new JsonSerializerSettings
            {
                DateFormatString = "ddd MMM dd HH:mm:ss zzzz yyyy"
            };
        }

        public static T ParseJsonObject<T>(this string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSetting);
        }
        public static T[] ParseJsonArray<T>(this string json)
            where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T[]>(json, JsonSetting);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static bool CheckFiltered(this Rule rule, Status status)
        {
            throw new NotImplementedException();
        }

        public static string GetDisplayText(this Status status)
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
                var withUrls  = enti.Urls  != null && enti.Urls .Length > 0;

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
