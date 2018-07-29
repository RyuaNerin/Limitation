using System;
using System.Collections.Generic;
using System.Threading;
using Limitation.Twitter.BaseModel;
using Limitation.Twitter.Objects;

namespace Limitation.Twitter
{
    internal static class InternedHelper
    {
        private static SortedList<long, WeakReference<UserObject>> UserCollection   = new SortedList<long, WeakReference<UserObject>>(200);
        private static SortedList<long, WeakReference<StatusObject>> StatusCollection = new SortedList<long, WeakReference<StatusObject>>(1024);

        public static IEnumerable<StatusObject> ToInterned(this IEnumerable<StatusObject> statuses)
        {
            foreach (var item in statuses)
                yield return item.Intern();
        }

        public static StatusObject Intern(this StatusObject status)
        {
            bool newItem = false;
            StatusObject interned;

            lock (StatusCollection)
            {
                if (!StatusCollection.ContainsKey(status.Id))
                {
                    StatusCollection[status.Id] = new WeakReference<StatusObject>(interned = status);
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

        public static UserObject Intern(this UserObject user)
        {
            UserObject interned;

            lock (UserCollection)
            {
                if (!UserCollection.ContainsKey(user.Id))
                {
                    UserCollection[user.Id] = new WeakReference<UserObject>(interned = user);
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
