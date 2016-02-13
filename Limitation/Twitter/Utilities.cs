using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Limitation.Twitter
{
    internal class Utilities
    {
        private static IDictionary<Type, DataContractJsonSerializer> m_table = new Dictionary<Type, DataContractJsonSerializer>();
        private static DataContractJsonSerializerSettings m_serializerSetting = new DataContractJsonSerializerSettings { DateTimeFormat = new DateTimeFormat("")};

        public static T ParseJsonObject<T>(string json)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var type = typeof(T);

                DataContractJsonSerializer serializer;
                lock (m_table)
                {
                    if (m_table.ContainsKey(type))
                        serializer = Utilities.m_table[type];
                    else
                        Utilities.m_table.Add(type, serializer = new DataContractJsonSerializer(type, Utilities.m_serializerSetting));
                }

                return (T)serializer.ReadObject(stream);
            }
        }
        public static T[] ParseJsonArray<T>(string json)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var type = typeof(T[]);

                DataContractJsonSerializer serializer;
                lock (m_table)
                {
                    if (m_table.ContainsKey(type))
                        serializer = Utilities.m_table[type];
                    else
                        Utilities.m_table.Add(type, serializer = new DataContractJsonSerializer(type, Utilities.m_serializerSetting));
                }

                return (T[])serializer.ReadObject(stream);
            }
        }
    }
}
