using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Threading;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;
using Limitation.Twitter.Streaming;

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
        private long m_maxId = -1;
        private long m_sinceId = -1;

        public Profile Profile { get; private set; }
        public string Name { get; set; }

        public abstract bool SupportStreaming { get; }
        public abstract TimeLineTypes TimeLineType { get; }

        public abstract string GetUrl(long maxId, long sinceId);

        public virtual void GetNewTweets()
        {
            Task.Factory.StartNew(new Action<object>(this.GetNewTweets), this.GetUrl(this.m_maxId, this.m_sinceId));
        }
        public virtual void GetNewTweets(object uriObj)
        {
            var uri = uriObj as string;

            this.Profile.OAuth.CreateWebRequest("GET", uri);
        }

        private void StatusUpdated(TwitterStreaming sender, Status status)
        {
            if (this.Filter(status)) this.Add(status);
        }

        private new void Add(Status status)
        {
            lock (m_ids) if (m_ids.Contains(status.Id)) return;

            if (this.m_maxId == -1)                 this.m_maxId = status.Id;
            else if (this.m_maxId > status.Id)      this.m_maxId = status.Id;

            if (this.m_sinceId == -1)               this.m_sinceId = status.Id;
            else if (this.m_sinceId > status.Id)    this.m_sinceId = status.Id;

            this.m_dispatcher.Invoke(new Action<Status>(base.Add), status);
        }

        protected virtual bool Filter(Status status)
        {
            return true;
        }

        private IList<long> m_ids = new List<long>();
        protected override void ClearItems()
        {
            base.ClearItems();
            this.m_ids.Clear();
        }
        protected override void InsertItem(int index, Status item)
        {
            base.InsertItem(index, item);
            this.m_ids.Add(item.Id);
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            this.m_ids.RemoveAt(index);
        }
    }
}
