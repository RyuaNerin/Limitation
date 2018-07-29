using System;
using System.Windows;
using System.Windows.Input;
using Limitation.Helpers;
using PropertyChanged;

namespace Limitation.Windows
{
    [AddINotifyPropertyChangedInterface]
    internal partial class PinWindow : Window
    {
        private ClipboardMonitor m_clipboardMonitor;

        public PinWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_clipboardMonitor = new ClipboardMonitor(this);
            this.m_clipboardMonitor.ClipboardChanged += this.m_clipboardMonitor_ClipboardChanged;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.m_clipboardMonitor.ReleaseHandle();
        }

        private void m_clipboardMonitor_ClipboardChanged(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                var str = Clipboard.GetText(TextDataFormat.Text);
                if (!string.IsNullOrWhiteSpace(str) && str.Length == 7 && int.TryParse(str, out int i))
                {
                    this.PinText = str;
                }
            }
        }

        public string PinText { get; set; }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Button_Click(null, null);
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int i);
        }
    }
}
