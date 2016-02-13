using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Limitation.Twitter.Model
{
    internal class TwModel<T> : IComparable, IComparable<TwModel<T>>, IEquatable<TwModel<T>>, INotifyPropertyChanged
    {
        public virtual long Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static T[] ParseJsonArray(string json)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T[]));
                return (T[])serializer.ReadObject(stream);
            }
        }
        public static T ParseJsonObject(string json)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        public int CompareTo(object obj)
        {
            return GetType() == obj.GetType() ? ((TwModel<T>)obj).Id.CompareTo(this.Id) : 0;
        }
        public int CompareTo(TwModel<T> obj)
        {
            return this.Id.CompareTo(obj.Id);
        }
        public bool Equals(TwModel<T> other)
        {
            return other.Id == this.Id;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
