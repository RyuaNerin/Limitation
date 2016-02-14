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

        public virtual int CompareTo(object obj)
        {
            return this.GetType() == obj.GetType() ? this.CompareTo(obj as BaseModel<T>) : 0;
        }
        public virtual int CompareTo(BaseModel<T> obj)
        {
            throw new NotImplementedException();
        }
        public virtual bool Equals(BaseModel<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
