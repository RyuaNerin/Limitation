using System;
using System.Windows.Threading;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;
using Limitation.Twitter.Streaming.Model;

namespace Limitation.Twitter.TimeLine
{
    internal abstract class BaseTimeLine : SortedObservableCollection<Status>, IDisposable
    {
        public BaseTimeLine(Profile profile)
        {
            this.m_dispatcher = App.Current.Dispatcher;
            this.Profile = profile;

            if (this.SupportStreaming) this.Profile.Streaming.OnStatusUpdated += this.StatusUpdated;
        }

        ~BaseTimeLine()
        {
            this.Dispose(false);
        }

        private bool m_disposed;
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
                if (this.SupportStreaming) this.Profile.Streaming.OnStatusUpdated -= this.StatusUpdated;
            }
        }

        private readonly Dispatcher m_dispatcher;
        protected long m_maxId = -1;

        public Profile Profile { get; private set; }
        public string Name { get; set; }

        public abstract bool SupportStreaming { get; }
        public abstract TimeLineTypes TimeLineType { get; }       
        
        public virtual void GetMore()
        { }

        private void StatusUpdated(TwitterStreaming sender, Status status)
        {
            if (this.Filter(status)) this.Add(status);
        }

        private new void Add(Status status)
        {
            this.m_dispatcher.Invoke(new Action<Status>(base.Add), status);

            if (this.m_maxId == -1)
                this.m_maxId = status.Id;
            else if (this.m_maxId > status.Id)
                this.m_maxId = status.Id;
        }

        protected virtual bool Filter(Status status)
        {
            return true;
        }
    }
}
