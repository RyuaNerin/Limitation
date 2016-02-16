using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.Containers
{
    internal static class Container
    {
        private static SortedList<long, WeakReference> m_user   = new SortedList<long, WeakReference>(200);
        private static SortedList<long, WeakReference> m_status = new SortedList<long, WeakReference>(1024);
        private static SortedList<long, WeakReference> m_list   = new SortedList<long, WeakReference>(32);

        public static User Intern(this User user)
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

        public static Status Intern(this Status status)
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

        public static List Intern(this List list)
        {
            lock (m_list)
            {
                List interned;

                if (!m_user.ContainsKey(list.Id))
                    m_list[list.Id] = new WeakReference(interned = list);
                else if (!m_list[list.Id].IsAlive)
                    m_list[list.Id].Target = (interned = list);
                else
                {
                    interned = m_list[list.Id].Target as List;
                    interned.Update(list);
                }

                return list;
            }
        }

        private static Timer m_cleanUpTimer = new Timer(Container.CleanUp, null, 3 * 60 * 1000, 3 * 60 * 1000);
        private static void CleanUp(object state)
        {
            CleanUp(m_list);
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
