using System;
using System.Collections.Generic;
using System.Threading;
using Limitation.Twitter.Model;

namespace Limitation.Twitter
{
    internal static class Container
    {
        private static SortedList<long, WeakReference> m_user   = new SortedList<long, WeakReference>(200);
        private static SortedList<long, WeakReference> m_status = new SortedList<long, WeakReference>(1024);

        public static User IsInterned(this User user)
        {
            lock (m_user)
            {
                User interned;

                if (!m_user.ContainsKey(user.Id))
                    m_user[user.Id] = new WeakReference(interned = user);
                else if (!m_user[user.Id].IsAlive)
                    m_user[user.Id].Target = (interned = user);
                else
                {
                    interned = m_user[user.Id].Target as User;
                    interned.Update(user);
                }

                return user;
            }
        }

        public static Status IsInterned(this Status status)
        {
            lock (m_status)
            {
                Status interned;

                if (!m_status.ContainsKey(status.Id))
                    m_status[status.Id] = new WeakReference(interned = status);
                else if (!m_status[status.Id].IsAlive)
                    m_status[status.Id].Target = (interned = status);
                else
                {
                    interned = m_status[status.Id].Target as Status;
                    interned.Update(status);
                }

                return status;
            }
        }

        private static Timer m_cleanUpTimer = new Timer(Container.CleanUp, null, 3 * 60 * 1000, 3 * 60 * 1000);
        private static void CleanUp(object state)
        {
            CleanUp(m_status);
            CleanUp(m_user);
        }
        private static void CleanUp(SortedList<long, WeakReference> lst)
        {
            int i;
            long id;

            lock (lst)
            {
                i = 0;
                while (i < lst.Count)
                {
                    id = lst.Keys[i];
                    if (!lst[id].IsAlive)
                        lst.Remove(id);
                    else
                        i++;
                }
            }
        }
    }
}
