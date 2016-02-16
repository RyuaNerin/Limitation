using System;
using System.Collections.ObjectModel;

namespace Limitation.Twitter
{
    internal class SortedObservableCollection<T> : ObservableCollection<T>
        where T : IComparable
    {
        protected override void InsertItem(int index, T item)
        {
            for (var i = 0; i < this.Count; i++)
            {
                switch (Math.Sign(this[i].CompareTo(item)))
                {
                    case 0:
                    case 1:
                        base.InsertItem(i, item);
                        return;
                    case -1:
                        break;
 
                }
            }

            base.InsertItem(Count, item);
        }
    }
}
