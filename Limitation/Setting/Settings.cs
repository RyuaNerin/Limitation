using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Limitation.Setting.Objects;

namespace Limitation.Setting
{
    internal class SettingAttr : Attribute { }

    [Serializable]
	internal class Settings
    {
        public static Settings Instance { get; private set; } 
        
		private static readonly string SettingFilePath;
		static Settings()
		{
            Instance = new Settings();
			SettingFilePath = Path.Combine(App.DirPath, "limitation.ini");
		}
        private Settings()
        {
            LoadSetting();
        }

        private static PropertyInfo[][] GetPropertiesSplited(Type type, bool @readonly = true)
        {
            var props = GetProperties(type, @readonly);

            return new PropertyInfo[][] { props.Where(e => !e.GetGetMethod().ReturnType.IsClass).ToArray(), props.Where(e =>  e.GetGetMethod().ReturnType.IsClass).ToArray() };
        }
        private static PropertyInfo[] GetProperties(Type type, bool @readonly = true)
        {
            return type
                   .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | (@readonly ? BindingFlags.Default : BindingFlags.SetProperty))
                   .Where(e => e.CustomAttributes.Any(ee => ee.AttributeType == typeof(SettingAttr)))
                   .ToArray();
        }

        public static void SaveSetting()
        {
            using (var writer = new StreamWriter(SettingFilePath))
            {
                MethodInfo method;
                Type resultType;

                var props = GetPropertiesSplited(typeof(Settings));
                
                if (props[0].Length > 0)
                {
                    writer.WriteLine("[Settings]");
                    foreach (var prop in props[0])
                        writer.WriteLine("{0}={1}", prop.Name, Object2String(prop.GetValue(Settings.Instance)));
                }

                foreach (var prop in props[1])
                {
                    method = prop.GetGetMethod();
                    resultType = method.ReturnType;

                    if (!resultType.IsClass)
                    {
                        if (resultType.IsGenericType)
                        {
                            foreach (var subValue in (IEnumerable)prop.GetValue(Settings.Instance))
                            {
                                writer.WriteLine("[{0}]", prop.Name);
                                foreach (var subProp in GetProperties(subValue.GetType(), false))
                                    writer.WriteLine("{0}={1}", subProp.Name, Object2String(subProp.GetValue(subValue)));
                            }
                        }
                        else
                        {
                            var value = prop.GetValue(Settings.Instance);

                            writer.WriteLine("[{0}]", prop.Name);
                            foreach (var subProp in GetProperties(value.GetType(), false))
                                writer.WriteLine("{0}={1}", subProp.Name, Object2String(subProp.GetValue(value)));
                        }
                    }                    
                }
            }
        }
        private static void LoadSetting()
        {
            if (!File.Exists(SettingFilePath)) return;

            PropertyInfo[][] groupProps = GetPropertiesSplited(typeof(Settings));
            PropertyInfo[]   valueProps = null;

            object groupValue = null;
            
            //////////////////////////////////////////////////
            PropertyInfo   valueProp  = null;            
            string[] prop;

            using (var reader = new StreamReader(SettingFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("["))
                    {
                        line = line.Substring(1, line.Length - 2).ToLower();
                        if (line == "Settings")
                        {
                            groupValue = Settings.Instance;
                            valueProps = groupProps[0];
                        }
                        else
                        {
                            groupValue = groupProps[1].First(e => e.Name == line).GetValue(Settings.Instance);

                            var groupType = groupValue.GetType();
                            if (groupType.IsGenericType)
                            {
                                var method = groupType.GetMethod("Add");
                                var newValue = Activator.CreateInstance(groupType.GetGenericArguments()[0]);
                                method.Invoke(groupValue, new object[] { newValue });
                            }

                            valueProps = GetProperties(groupType, false).ToArray();
                        }
                    }
                    else if (groupValue != null)
                    {
                        prop = line.Split('=');
                        if (prop.Length == 2)
                        {
                            valueProp = valueProps.First(e => e.Name == prop[0]);

                            try
                            {
                                valueProp.SetValue(groupValue, String2Object(prop[1], valueProp.PropertyType));
                            }
                            catch
                            { }
                        }
                    }
                }
            }

            Settings.Instance.Proxy.SetProxy();
        }

        private static Type[] types = { typeof(string), typeof(bool), typeof(int) };
        private static object String2Object(string value, Type type)
        {
            if (type == types[0])   return value;
            if (type == types[1])   return value == "1";
            if (type == types[2])   return int.Parse(value);
            return null;
        }
        private static string Object2String(object value)
        {
            if (value is string)    return (string)value;
            if (value is bool)      return (bool)value ? "1" : "0";
            if (value is int)       return value.ToString();
            return null;
        }

        //////////////////////////////////////////////////

        private List<Profile> m_list = new List<Profile>();
        [SettingAttr]
        public List<Profile> List { get { return m_list; } }

        private Proxy m_proxy = new Proxy();
        [SettingAttr]
        public Proxy Proxy { get { return m_proxy; } }

        private Window m_window = new Window();
        [SettingAttr]
        public Window Window { get { return m_window; } }
	}
}
