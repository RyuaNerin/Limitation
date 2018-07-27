using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Limitation.Twitter.Model
{
    internal interface ITwitterObject : IComparable
    {
        long Id { get; }
    }

    internal abstract class TwitterObject<T> : ITwitterObject, IComparable<T>, IEquatable<T>, INotifyPropertyChanged
        where T : ITwitterObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract long Id { get; set; }

        public int CompareTo(object obj)
        {
            return this.GetType() == obj.GetType() ? this.CompareTo(obj as ITwitterObject) : 0;
        }
        public bool Equals(T other)
        {
            return this.CompareTo(other) == 0;
        }
        public int CompareTo(T other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public void Update(T newObject)
        {
            var type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(this, prop.GetValue(newObject, null));
            }
        }
    }
}
