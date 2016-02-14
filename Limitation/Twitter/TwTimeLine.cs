using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;
using Limitation.Twitter.Objects;

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

    internal abstract class TwTimeLine : SortedObservableCollection<Status>
    {
        public TwTimeLine(Profile profile)
        {
            this.m_dispatcher = App.Current.Dispatcher;
            this.Profile = profile;

            this.AttachStream();
        }
        ~TwTimeLine()
        {
            this.Dispose(false);
        }

        private bool m_disposed = false;
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (this.m_disposed) return;
            this.m_disposed = true;

            if (disposing)
            {
                this.DeattachStream();
            }
        }

        private readonly Dispatcher m_dispatcher;

        public abstract TimeLineTypes TimeLineType { get; }
        public Profile Profile { get; private set; }
        public string Name { get; set; }

        public long MaxId { get; private set; }

        public void GetMore()
        {

        }

        protected virtual void AttachStream()
        {
            throw new NotImplementedException();
        }

        protected virtual void DeattachStream()
        {
            throw new NotImplementedException();
        }

        private new void Add(Status status)
        {
            this.m_dispatcher.Invoke(new Action<Status>(base.Add), status);
        }

        protected virtual bool Filter(Status status)
        {
            return true;
        }
    }
}
