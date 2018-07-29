using System;
using Limitation.Twitter.BaseModel;
using PropertyChanged;

namespace Limitation.Windows.Controls
{
    [AddINotifyPropertyChangedInterface]
    internal class TweetControl : IComparable<TweetControl>, IEquatable<TweetControl>
    {
        public TweetControl(Status status)
        {
            this.TwitterStatus = status;
        }

        public Status TwitterStatus { get; }

        public Status[] SubStatus { get; set; }

        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }

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
