using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Limitation.Twitter.Model;
using System.Threading;
using System.Net;
using Limitation.Setting.Objects;

namespace Limitation.Twitter
{
    internal enum TimeLineTypes
    {
        Home,
        Mention,
        DirectMessege,
        Bio,
        Follower,
        Following,
        Favorite,
        List,
        Search
    }

    internal abstract class TwTimeLine : ObservableCollection<Status>
    {
        public TwTimeLine(Profile profile)
        {
            this.m_dispatcher = App.Current.Dispatcher;

            this.Profile = profile;
        }

        private bool m_disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (this.m_disposed) return;
            this.m_disposed = true;

            if (disposing)
            {

            }
        }

        private readonly Dispatcher m_dispatcher;

        public virtual TimeLineTypes TimeLineType { get; }
        public Profile Profile { get; private set; }
        public string Name { get; set; }

        private void Recieve(Status status)
        {

        }

        protected virtual bool Filter(Status status)
        {
            return true;
        }
    }
}
