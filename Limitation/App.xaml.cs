using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Limitation.Setting;

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
            var asm = Assembly.GetExecutingAssembly();

            ExePath = Path.GetFullPath(asm.Location);
            DirPath = Path.GetDirectoryName(App.ExePath);
            Version = asm.GetName().Version;
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Options.Save();
        }
    }
}
