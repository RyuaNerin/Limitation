using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Limitation.Setting.Objects;
using Newtonsoft.Json;
using PropertyChanged;

namespace Limitation.Setting
{
    [JsonObject]
	internal class Options
    {
        public static Options Instance { get; } = new Options();

        private static readonly string ConfigPath  = Path.ChangeExtension(App.ExePath, "Limitation.cfg");
        private static readonly string ConfigPath2 = Path.ChangeExtension(App.ExePath, "Limitation.cfg.new");
        private static readonly JsonSerializer Serializer = JsonSerializer.Create();

        static Options()
        {
            //Serializer.Formatting = Formatting.Indented;

            if (File.Exists(ConfigPath))
            {
                try
                {
                    using (var fs = File.OpenRead(ConfigPath))
                    using (var sr = new StreamReader(fs, Encoding.UTF8))
                    using (var br = new JsonTextReader(sr))
                        Serializer.Populate(br, Instance);
                }
                catch
                {
                }
            }
        }

        private static readonly object SaveSync = new object();
        public static void Save()
        {
            if (Monitor.TryEnter(SaveSync, 0))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));

                    using (var fs = File.OpenWrite(ConfigPath2))
                    {
                        fs.SetLength(0);

                        using (var sr = new StreamWriter(fs, Encoding.UTF8))
                        using (var br = new JsonTextWriter(sr))
                            Serializer.Serialize(br, Instance);
                    }

                    File.Delete(ConfigPath);
                    File.Move(ConfigPath2, ConfigPath);
                }
                catch
                {
                    File.Delete(ConfigPath2);
                }
                finally
                {
                    Monitor.Exit(SaveSync);
                }
            }
        }

        //////////////////////////////////////////////////

        [JsonProperty("profiles", DefaultValueHandling = DefaultValueHandling.Populate)]
        public List<Profile> Profiles { get; } = new List<Profile>();

        [JsonProperty("window", DefaultValueHandling = DefaultValueHandling.Populate)]
        public WindowOption Window { get; } = new WindowOption();
        
        [JsonProperty("design", DefaultValueHandling = DefaultValueHandling.Populate)]
        public DesignOption Design { get; } = new DesignOption();

        [JsonProperty("tweeets_load_count")]
        public int TweetsLoadCount { get; set; } = 20;
	}
}
