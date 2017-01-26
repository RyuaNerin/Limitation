using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Limitation
{
	internal partial class App : Application
    {
        public const string AppToken  = "uLu4fcxGhXU8n9B4oVOYABNCH";
        public const string AppSecret = "I3bqrvlmaBgGocwopuihuDUaT1MNfvYa5Samjn9pPAnzEd0uZ8";

        public static readonly string  ExePath;
        public static readonly string  DirPath;
        public static readonly Version Version;
        
        static App()
        {
            App.m_assembly = Assembly.GetExecutingAssembly();
            App.m_assemblyNames = m_assembly.GetManifestResourceNames();

            App.ExePath = Path.GetFullPath(App.m_assembly.Location);
            App.DirPath	= Path.GetDirectoryName(App.ExePath);
            App.Version = m_assembly.GetName().Version;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static readonly Assembly m_assembly;
        private static readonly string[] m_assemblyNames;
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var eInfo = new AssemblyName(args.Name);

            for (int i = 0; i < App.m_assemblyNames.Length; ++i)
            {
                if (App.m_assemblyNames[i].Contains(eInfo.Name))
                {
                    using (var stream = App.m_assembly.GetManifestResourceStream(App.m_assemblyNames[i]))
                    {
                        byte[] buff = new byte[stream.Length];
                        stream.Read(buff, 0, buff.Length);

                        return Assembly.Load(buff);
                    }
                }
            }

            return null;
        }
    }
}
