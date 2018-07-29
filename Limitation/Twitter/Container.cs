using System;
using System.Collections.Generic;
using System.Threading;
using Limitation.Twitter.BaseModel;

namespace Limitation.Twitter
{
    internal static class Container
    {
        private static SortedList<long, WeakReference<User>> UserCollection   = new SortedList<long, WeakReference<User>>(200);
        private static SortedList<long, WeakReference<Status>> StatusCollection = new SortedList<long, WeakReference<Status>>(1024);

        public static IEnumerable<Status> ToInterned(this IEnumerable<Status> statuses)
        {
            foreach (var item in statuses)
                yield return item.Intern();
        }

        public static Status Intern(this Status status)
        {
            bool newItem = false;
            Status interned;

            lock (StatusCollection)
            {
                if (!StatusCollection.ContainsKey(status.Id))
                {
                    StatusCollection[status.Id] = new WeakReference<Status>(interned = status);
                    newItem = true;
                }
                else
                {
                    if (!StatusCollection[status.Id].TryGetTarget(out interned))
                        StatusCollection[status.Id].SetTarget(interned = status);
                }
            }

            if (newItem)
            {
                status.User = status.User.Intern();

                if (interned.QuotedStatus != null)
                    interned.QuotedStatus = interned.QuotedStatus.Intern();

                if (interned.RetweetedStatus != null)
                    interned.RetweetedStatus = interned.RetweetedStatus.Intern();
            }

            return interned;
        }

        public static User Intern(this User user)
        {
            User interned;

            lock (UserCollection)
            {
                if (!UserCollection.ContainsKey(user.Id))
                {
                    UserCollection[user.Id] = new WeakReference<User>(interned = user);
                }
                else
                {
                    if (!UserCollection[user.Id].TryGetTarget(out interned))
                        UserCollection[user.Id].SetTarget(interned = user);
                }
            }

            return interned;
        }

        private static readonly Timer CleanUpTimer = new Timer(CleanUp, null, 3 * 60 * 1000, 3 * 60 * 1000);
        private static void CleanUp(object state)
        {
            CleanUpList(StatusCollection);
            CleanUpList(UserCollection);
        }
        private static void CleanUpList<T>(SortedList<long, WeakReference<T>> lst)
            where T: class, ITwitterObject
        {
            int i;
            long id;

            lock (lst)
            {
                i = 0;
                while (i < lst.Count)
                {
                    id = lst.Keys[i];
                    if (!lst[id].TryGetTarget(out T t))
                        lst.Remove(id);
                    else
                        i++;
                }
            }
        }
    }
}
