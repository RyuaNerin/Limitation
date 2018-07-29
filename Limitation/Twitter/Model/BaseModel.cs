using System;

namespace Limitation.Twitter.BaseModel
{
    internal interface ITwitterObject : IComparable
    {
        long Id { get; }
    }

    internal abstract class TwitterObject<T> : ITwitterObject, IComparable<T>, IEquatable<T>
        where T : class, ITwitterObject
    {
        public abstract long Id { get; set; }

        public int CompareTo(object obj)
        {
            return this.GetType() == obj.GetType() ? this.CompareTo(obj as T) : 0;
        }
        public int CompareTo(T obj)
        {
            return this.Id.CompareTo(obj.Id);
        }
        public bool Equals(T other)
        {
            return this.GetType() == other.GetType() && this.CompareTo(other) == 0;
        }
    }
}
