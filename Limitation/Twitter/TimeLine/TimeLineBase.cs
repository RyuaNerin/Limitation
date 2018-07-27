using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Limitation.Setting;
using Limitation.Setting.Objects;
using Limitation.Twitter.Model;

namespace Limitation.Twitter.TimeLine
{
    internal abstract class BaseTimeLine
    {
        public BaseTimeLine(Profile profile)
        {
            this.Profile = profile;
        }

        public SortedObservableCollection<Status> TWeetObjects { get; } = new SortedObservableCollection<Status>();

        public Profile Profile { get; protected set; }

        public long TargetId { get; protected set; }

        // <- since_id --------------- max_id ->
        protected long MaxId   { get; set; } = long.MinValue;
        protected long SinceId { get; set; } = long.MaxValue;

        public abstract TimeLineTypes TimeLineType { get; }

        public void GetNewTweets()
        {
            Task.Factory.StartNew(new Action(this.GetNewTweetsPriv));
        }

        protected abstract void GetNewTweetsPriv();

        private void Add(IEnumerable<Status> statuses)
        {
            foreach (var status in statuses)
            {
                if (this.MaxId   > status.Id) this.MaxId   = status.Id;
                if (this.SinceId > status.Id) this.SinceId = status.Id;

                if (this.Filter(status))
                    App.Current.Dispatcher.Invoke(new Action<Status>(this.TWeetObjects.Add), status);
            }
        }

        protected virtual bool Filter(Status status)
        {
            return true;

            // TO-DO
        }
    }
}
