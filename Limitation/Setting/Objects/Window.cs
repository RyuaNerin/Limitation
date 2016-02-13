using Limitation.Windows;

namespace Limitation.Setting.Objects
{
    internal class Window
    {
        private long m_x = -1;
        [SettingAttr]
        public int X
        {
            get { return (int)MainWindow.Instance.Left; }
            set { this.m_x = value; }
        }

        private long m_y = -1;
        [SettingAttr]
        public int Y
        {
            get { return (int)MainWindow.Instance.Top; }
            set { this.m_y = value; }
        }

        private long m_w = -1;
        [SettingAttr]
        public int W
        {
            get { return (int)MainWindow.Instance.Width; }
            set { this.m_w = value; }
        }

        private long m_h = -1;
        [SettingAttr]
        public int H
        {
            get { return (int)MainWindow.Instance.Height; }
            set { this.m_h = value; }
        }
    }
}
