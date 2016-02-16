using System.Net;
using Limitation.Twitter.Model;
using Limitation.Twitter.Streaming.Model;

namespace Limitation.Twitter.Streaming
{
    internal delegate void OnStreamingConnected(TwitterStreaming sender);
    internal delegate void OnStreamingError(TwitterStreaming sender, WebException exception);
    internal delegate void OnStreamingDisconnected(TwitterStreaming sender);

    internal delegate void OnDelete(TwitterStreaming sender, Delete @event);
    internal delegate void OnScrubGeo(TwitterStreaming sender, ScrubGeo @event);
    internal delegate void OnLimit(TwitterStreaming sender, Limit @event);
    internal delegate void OnStatusWithheld(TwitterStreaming sender, StatusWithheld @event);
    internal delegate void OnUserWithheld(TwitterStreaming sender, UserWithheld @event);
    internal delegate void OnDisconnected(TwitterStreaming sender, Disconnect @event);

    internal delegate void OnStallWarning(TwitterStreaming sender, StallWarning @event);
    internal delegate void OnTooManyFollowsWarning(TwitterStreaming sender, TooManyFollowsWarning @event);

    internal delegate void OnFriends(TwitterStreaming sender, long[] @event);

    internal delegate void OnUserUpdate(TwitterStreaming sender, UserUpdate @event);
    internal delegate void OnUserDeauthorizesStream(TwitterStreaming sender, UserDeauthorizesStream @event);
    internal delegate void OnBlock(TwitterStreaming sender, Block @event);
    internal delegate void OnUnblock(TwitterStreaming sender, Unblock @event);
    internal delegate void OnFavorite(TwitterStreaming sender, Favorite @event);
    internal delegate void OnUnfavorite(TwitterStreaming sender, Unfavorite @event);
    internal delegate void OnFollow(TwitterStreaming sender, Follow @event);
    internal delegate void OnUnfollow(TwitterStreaming sender, Unfollow @event);
    internal delegate void OnListCreated(TwitterStreaming sender, ListCreated @event);
    internal delegate void OnListDestroyed(TwitterStreaming sender, ListDestroyed @event);
    internal delegate void OnListUpdated(TwitterStreaming sender, ListUpdated @event);
    internal delegate void OnListMemberAdded(TwitterStreaming sender, ListMemberAdded @event);
    internal delegate void OnListMemberRemoved(TwitterStreaming sender, ListMemberRemoved @event);
    internal delegate void OnListUserSubscribed(TwitterStreaming sender, ListUserSubscribed @event);
    internal delegate void OnListUserUnsubscribed(TwitterStreaming sender, ListUserUnsubscribed @event);
    internal delegate void OnQuotedTweet(TwitterStreaming sender, QuotedTweet @event);

    internal delegate void OnStatusUpdated(TwitterStreaming sender, Status @event);
}
