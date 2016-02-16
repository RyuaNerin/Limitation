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

            if (Options.Instance.Window.X != -1) this.Left   = Options.Instance.Window.X;
            if (Options.Instance.Window.Y != -1) this.Top    = Options.Instance.Window.Y;
            if (Options.Instance.Window.W != -1) this.Width  = Options.Instance.Window.W;
            if (Options.Instance.Window.H != -1) this.Height = Options.Instance.Window.H;
		}
	}
}
