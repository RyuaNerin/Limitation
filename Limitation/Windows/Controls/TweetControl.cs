using System;
using System.ComponentModel;
using Limitation.Twitter.BaseModel;
using Limitation.Twitter.Objects;
using PropertyChanged;

namespace Limitation.Windows.Controls
{
    internal class TweetControl : IComparable<TweetControl>, IEquatable<TweetControl>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TweetControl(StatusObject status)
        {
            this.TwitterStatus = status;
        }

        public StatusObject TwitterStatus { get; }

        public StatusObject[] SubStatus { get; set; }

        public bool IsSelected { get; set; }

        private bool m_isExpanded = false;
        public bool IsExpanded
        {
            get => m_isExpanded;
            set
            {
                this.m_isExpanded = true;
                
            }
        }

        public int CompareTo(object obj)
        {
            return this.GetType() == obj.GetType() ? this.CompareTo(obj as ITwitterObject) : 0;
        }
        public int CompareTo(TweetControl obj)
        {
            return this.TwitterStatus.CompareTo(obj.TwitterStatus);
        }
        public bool Equals(TweetControl other)
        {
            return this.CompareTo(other) == 0;
        }

    }
}
