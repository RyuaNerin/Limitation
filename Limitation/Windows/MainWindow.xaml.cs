using System.Windows;
using Limitation.Setting;

namespace Limitation.Windows
{
	internal partial class MainWindow : Window
	{
        public static MainWindow Instance { get; private set; }

		public MainWindow()
		{
            Instance = this;

			InitializeComponent();
		}
	}
}
