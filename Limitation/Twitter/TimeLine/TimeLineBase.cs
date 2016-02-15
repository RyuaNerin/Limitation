using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;
using Limitation.Twitter.Streaming;

namespace Limitation.Twitter
{
    internal abstract class BaseTimeLine : SortedObservableCollection<Status>
    {
        public BaseTimeLine(Profile profile)
        {
            this.m_dispatcher = App.Current.Dispatcher;
            this.Profile = profile;
        }

        private readonly Dispatcher m_dispatcher;

        public abstract TimeLineTypes TimeLineType { get; }
        public Profile Profile { get; private set; }
        public string Name { get; set; }

        public long MaxId { get; private set; }

        public void GetMore()
        {

        }

        private void RecievedTweet()
        {

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
