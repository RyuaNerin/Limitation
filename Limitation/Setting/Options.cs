using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Limitation.Setting.Objects;

namespace Limitation.Setting
{
    internal class SettingAttr : Attribute { }

    [DataContract]
	internal class Options
    {
        public static Options Instance { get; private set; }

        private static DataContractJsonSerializer m_serializer = new DataContractJsonSerializer(typeof(Options));
		private static readonly string SettingFilePath;
		static Options()
		{
			SettingFilePath = Path.Combine(App.DirPath, "limitation.ini");
            
            try
            {
                using (var file = File.OpenRead(SettingFilePath))
                    Options.Instance = m_serializer.ReadObject(file) as Options;
            }
            catch
            { }

            if (Options.Instance == null)
                Options.Instance = new Options();

            Options.Instance.Proxy.SetProxy();
		}
        public static void SaveSetting()
        {
            using (var file = File.OpenWrite(SettingFilePath))
                m_serializer.WriteObject(file, Options.Instance);
        }

        //////////////////////////////////////////////////

        private List<Profile> m_profiles;
        [DataMember(Name = "profiles")]
        public List<Profile> Profiles
        {
            get { return m_profiles ?? (m_profiles = new List<Profile>()); }
            set { if (value != null) m_profiles = value; }
        }

        private Proxy m_proxy;
        [DataMember(Name = "proxy")]
        public Proxy Proxy
        {
            get { return m_proxy ?? (m_proxy = new Proxy()); }
            set { if (value != null) m_proxy = value; }
        }

        private List<TimeLine> m_etc;
        [DataMember(Name = "timeline")]
        public List<TimeLine> TimeLine
        {
            get { return m_etc ?? (m_etc = new List<TimeLine>()); }
            set { if (value != null) m_etc = value; }
        }

        private Window m_window;
        [DataMember(Name = "window")]
        public Window Window
        {
            get { return m_window ?? (m_window = new Window()); }
            set { if (value != null) m_window = value; }
        }

        private Design m_design;
        [DataMember(Name = "design")]
        public Design Design
        {
            get { return m_design ?? (m_design = new Design()); }
            set { if (value != null) m_design = value; }
        }
	}
}
