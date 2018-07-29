using System;
using System.Collections.ObjectModel;

namespace Limitation.Twitter
{
    internal class SortedObservableCollection<T> : ObservableCollection<T>
        where T : IComparable<T>
    {
        protected override void InsertItem(int index, T item)
        {
            int min = this.Count - 1;
            int max = 0;
            int mid = 0;

            while (max <= min)
            {
                mid = (min + max) / 2;

                switch (this[mid].CompareTo(item))
                {                    
                    case  0: this[mid] = item;  return; // 같음
                    case -1: min = mid - 1;     break; // Id 가 작음 -> 밑으로
                    case  1: max = mid + 1;     break; // Id 가 큼 -> 위로
                }
            }

            base.InsertItem(mid, item);
        }
    }
}
