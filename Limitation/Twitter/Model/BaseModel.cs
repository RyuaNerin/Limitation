using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Limitation.Twitter.Model
{
    internal interface BaseModel : IComparable
    {
        Type ModelType { get; }
        long Id { get; }
    }

    internal abstract class BaseModel<T> : BaseModel, IComparable<T>, IEquatable<T>, INotifyPropertyChanged
        where T : BaseModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Type ModelType { get { return typeof(T); } }

        public abstract long Id { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(object obj)
        {
            return this.GetType() == obj.GetType() ? this.CompareTo(obj as BaseModel) : 0;
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
