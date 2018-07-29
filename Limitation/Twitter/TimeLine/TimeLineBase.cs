using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Limitation.Setting.Objects;
using Limitation.Twitter.BaseModel;
using System.Linq;
using Limitation.Windows.Controls;

namespace Limitation.Twitter.TimeLine
{
    internal abstract class BaseTimeLine
    {
        public BaseTimeLine(Profile profile)
        {
            this.Profile = profile;
        }

        public SortedObservableCollection<TweetControl> TweetObjects { get; } = new SortedObservableCollection<TweetControl>();

        public Profile Profile { get; protected set; }

        public long TargetId { get; protected set; }

        // <- since_id --------------- max_id ->
        protected long? MaxId   { get; set; }
        protected long? SinceId { get; set; }

        public abstract TimeLineTypes TimeLineType { get; }

        public void Update()
        {
            Task.Factory.StartNew(new Action(this.UpdatePriv));
        }

        protected abstract void UpdatePriv();

        protected void Add(IEnumerable<Status> statuses)
        {
            statuses = statuses.ToInterned();

            foreach (var status in statuses)
            {
                if (!this.MaxId  .HasValue || status.Id > this.MaxId  ) this.MaxId   = status.Id;
                if (!this.SinceId.HasValue || status.Id < this.SinceId) this.SinceId = status.Id;
            }

            App.Current.Dispatcher.Invoke(new Action<IEnumerable<TweetControl>>(this.AddToList), statuses.Where(e => Filter(e)).Select(e => new TweetControl(e)));
        }

        private void AddToList(IEnumerable<TweetControl> statuses)
        {
            foreach (var item in statuses)
                this.TweetObjects.Add(item);
        }

        private bool Filter(Status status)
        {
            return true;
            // TO-DO
        }
    }
}
