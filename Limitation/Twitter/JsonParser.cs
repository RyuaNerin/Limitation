using System;
using Limitation.Setting.Objects;
using Limitation.Twitter.BaseModel;
using Newtonsoft.Json;

namespace Limitation.Twitter
{
    internal static class JsonParser
    {
        private static readonly JsonSerializerSettings JsonSetting;

        static JsonParser()
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
    }
}
