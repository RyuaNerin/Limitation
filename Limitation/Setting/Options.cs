using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private List<Profile> m_profiles = new List<Profile>();
        [DataMember(Name = "profiles", EmitDefaultValue = false)]
        public List<Profile> Profiles
        {
            get { return m_profiles; }
        }

        private Proxy m_proxy = new Proxy();
        [DataMember(Name = "proxy", EmitDefaultValue = false)]
        public Proxy Proxy
        {
            get { return m_proxy; }
        }

        private List<TimeLine> m_etc = new List<TimeLine>();
        [DataMember(Name = "timeline", EmitDefaultValue = false)]
        public List<TimeLine> TimeLine
        {
            get { return m_etc; }
        }

        private Window m_window = new Window();
        [DataMember(Name = "window", EmitDefaultValue = false)]
        public Window Window
        {
            get { return m_window; }
        }

        private Design m_design = new Design();
        [DataMember(Name = "design", EmitDefaultValue = false)]
        public Design Design
        {
            get { return m_design; }
        }

        [DataMember(Name = "use_script")]
        [DefaultValue(true)]
        public bool UserScript { get; set; }

        [DataMember(Name = "allow_multi_instance")]
        [DefaultValue(false)]
        public bool AllowMultipleInstance { get; set; }

        [DataMember(Name = "tweeets_load_count")]
        [DefaultValue(20)]
        public int TweetsLoadCount { get; set; }
	}
}
