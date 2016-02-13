using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Limitation.Twitter.Model
{
    internal class BaseModel<T> : IComparable, IComparable<BaseModel<T>>, IEquatable<BaseModel<T>>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual long Id { get; set; }

        public int CompareTo(object obj)
        {
            return GetType() == obj.GetType() ? ((BaseModel<T>)obj).Id.CompareTo(this.Id) : 0;
        }
        public int CompareTo(BaseModel<T> obj)
        {
            return this.Id.CompareTo(obj.Id);
        }
        public virtual bool Equals(BaseModel<T> other)
        {
            return other.Id == this.Id;
        }
    }
}
