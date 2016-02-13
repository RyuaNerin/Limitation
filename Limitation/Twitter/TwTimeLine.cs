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

namespace Limitation.Twitter
{
    internal enum TimeLineType
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

    internal abstract class TwTimeLine : IDisposable
    {
        public TwTimeLine(TimeLineType type)
        {
            this.m_dispatcher = App.Current.Dispatcher;
            this.TimeLineType = type;
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
                this.m_cancel.Cancel();
                this.m_cancel.Dispose();
            }
        }

        private Task m_streaming;
        private CancellationTokenSource m_cancel;
        private readonly Dispatcher m_dispatcher;

        public TimeLineType TimeLineType { get; private set; }

        public void Connect()
        {
            this.m_cancel = new CancellationTokenSource();
            this.m_streaming = Task.Run(new Action(Streaming), this.m_cancel.Token);
        }

        public virtual void Streaming()
        { }
    }
}
