using System;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;
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

        public static T ParseJsonObject<T>(string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSetting);
        }
        public static T[] ParseJsonArray<T>(string json)
            where T : class
        {
            return JsonConvert.DeserializeObject<T[]>(json, JsonSetting);
        }


        public static bool CheckFiltered(this Rule rule, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
