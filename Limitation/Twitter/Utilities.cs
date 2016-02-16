using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Limitation.Twitter
{
    internal class Utilities
    {
        private static IDictionary<Type, DataContractJsonSerializer> m_table = new Dictionary<Type, DataContractJsonSerializer>();
        private static DataContractJsonSerializerSettings m_serializerSetting = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("ddd MMM dd HH:mm:ss zzzz yyyy")};

        public static T ParseJsonObject<T>(string json)
            where T: class
        {
            return ParseJson(typeof(T), json) as T;
        }
        public static T[] ParseJsonArray<T>(string json)
            where T : class
        {
            return ParseJson(typeof(T[]), json) as T[];
        }
        public static object ParseJson(Type type, string json)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer;
                lock (m_table)
                {
                    if (m_table.ContainsKey(type))
                        serializer = Utilities.m_table[type];
                    else
                        Utilities.m_table.Add(type, serializer = new DataContractJsonSerializer(type, Utilities.m_serializerSetting));
                }

                return serializer.ReadObject(stream);
            }
        }
    }
}
