using System.Windows;
using Limitation.Setting;
using MahApps.Metro.Controls;

namespace Limitation.Windows
{
	internal partial class MainWindow : MetroWindow
	{
        public static MainWindow Instance { get; private set; }

		public MainWindow()
		{
            Instance = this;

			InitializeComponent();

            if (Settings.Instance.Window.X != -1) this.Left   = Settings.Instance.Window.X;
            if (Settings.Instance.Window.Y != -1) this.Top    = Settings.Instance.Window.Y;
            if (Settings.Instance.Window.W != -1) this.Width  = Settings.Instance.Window.W;
            if (Settings.Instance.Window.H != -1) this.Height = Settings.Instance.Window.H;
		}
	}
}
