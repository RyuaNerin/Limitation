using System.Net;
using Limitation.Setting;

namespace Limitation.Twitter.Model.Streaming
{
    internal delegate void DeleteEvent(TwStreaming sender, STDelete @event);
    internal delegate void ScrubGeoEvent(TwStreaming sender, STScrubGeo @event);
    internal delegate void LimitEvent(TwStreaming sender, STLimit @event);
    internal delegate void StatusWitheldEvent(TwStreaming sender, STStatusWitheld @event);
    internal delegate void UserWitheldEvent(TwStreaming sender, STUserWithheld @event);
    internal delegate void DisconnectedEvent(TwStreaming sender, STDisconnect @event);

    internal delegate void StallWarningEvent(TwStreaming sender, STWarning @event);
    internal delegate void TooManyFollowsWarningEvent(TwStreaming sender, STWarning @event);
    
    internal delegate void FriendsEvent(TwStreaming sender, STFriends @event);

    internal delegate void UserUpdateEvent(TwStreaming sender, STUserUpdate @event);
    internal delegate void UserDeauthorizesStreamEvent(TwStreaming sender, STUserDeauthorizesStream @event);
    internal delegate void BlockEvent(TwStreaming sender, STBlock @event);
    internal delegate void UnblockEvent(TwStreaming sender, STUnblock @event);
    internal delegate void FavoriteEvent(TwStreaming sender, STFavorite @event);
    internal delegate void UnfavoriteEvent(TwStreaming sender, STUnfavorite @event);
    internal delegate void FollowEvent(TwStreaming sender, STFollow @event);
    internal delegate void UnfollowEvent(TwStreaming sender, STUnfollow @event);
    internal delegate void ListCreatedEvent(TwStreaming sender, STListCreated @event);
    internal delegate void ListDestroyedEvent(TwStreaming sender, STListDestroyed @event);
    internal delegate void ListUpdatedEvent(TwStreaming sender, STListUpdated @event);
    internal delegate void ListMemberAddedEvent(TwStreaming sender, STListMemberAdded @event);
    internal delegate void ListMemberRemovedEvent(TwStreaming sender, STListMemberRemoved @event);
    internal delegate void ListUserSubscribedEvent(TwStreaming sender, STListUserSubscribed @event);
    internal delegate void ListUserUnsubscribedEvent(TwStreaming sender, STListUserUnsubscribed @event);
    internal delegate void QuotedTweetEvent(TwStreaming sender, STQuotedTweet @event);

}
