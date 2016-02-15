using System.Net;
using Limitation.Setting;

namespace Limitation.Twitter.Streaming
{
    internal interface TwitterStreamingHandler
    {
        public virtual void OnConnected(TwitterStreaming sender);
        public virtual void OnError(TwitterStreaming sender, WebException exception);
        public virtual void OnDisconnected(TwitterStreaming sender);

        public virtual void OnDelete(TwitterStreaming sender, STDelete @event) { }
        public virtual void OnScrubGeo(TwitterStreaming sender, STScrubGeo @event) { }
        public virtual void OnLimit(TwitterStreaming sender, STLimit @event) { }
        public virtual void OnStatusWitheld(TwitterStreaming sender, STStatusWitheld @event) { }
        public virtual void OnUserWitheld(TwitterStreaming sender, STUserWithheld @event) { }
        public virtual void OnDisconnected(TwitterStreaming sender, STDisconnect @event) { }

        public virtual void OnStallWarning(TwitterStreaming sender, STWarning @event) { }
        public virtual void OnTooManyFollowsWarning(TwitterStreaming sender, STWarning @event) { }

        public virtual void OnFriends(TwitterStreaming sender, STFriends @event) { }

        public virtual void OnUserUpdate(TwitterStreaming sender, STUserUpdate @event) { }
        public virtual void OnUserDeauthorizesStream(TwitterStreaming sender, STUserDeauthorizesStream @event) { }
        public virtual void OnBlock(TwitterStreaming sender, STBlock @event) { }
        public virtual void OnUnblock(TwitterStreaming sender, STUnblock @event) { }
        public virtual void OnFavorite(TwitterStreaming sender, STFavorite @event) { }
        public virtual void OnUnfavorite(TwitterStreaming sender, STUnfavorite @event) { }
        public virtual void OnFollow(TwitterStreaming sender, STFollow @event) { }
        public virtual void OnUnfollow(TwitterStreaming sender, STUnfollow @event) { }
        public virtual void OnListCreated(TwitterStreaming sender, STListCreated @event) { }
        public virtual void OnListDestroyed(TwitterStreaming sender, STListDestroyed @event) { }
        public virtual void OnListUpdated(TwitterStreaming sender, STListUpdated @event) { }
        public virtual void OnListMemberAdded(TwitterStreaming sender, STListMemberAdded @event) { }
        public virtual void OnListMemberRemoved(TwitterStreaming sender, STListMemberRemoved @event) { }
        public virtual void OnListUserSubscribed(TwitterStreaming sender, STListUserSubscribed @event) { }
        public virtual void OnListUserUnsubscribed(TwitterStreaming sender, STListUserUnsubscribed @event) { }
        public virtual void OnQuotedTweet(TwitterStreaming sender, STQuotedTweet @event) { }
    }
}
