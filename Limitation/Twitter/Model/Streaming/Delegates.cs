using System.Net;
using Limitation.Setting;

namespace Limitation.Twitter.Model.Streaming
{
    internal delegate void StreamingConnected(TwStreaming sender);
    internal delegate void StreamingError(TwStreaming sender, WebException Exception);

    internal delegate void StreamingEventDelete(TwStreaming sender, DeleteEvent @event);
    internal delegate void StreamingEventScrubGeo(TwStreaming sender, ScrubGeoEvent @event);
    internal delegate void StreamingEventLimit(TwStreaming sender, LimitEvent @event);
    internal delegate void StreamingEventStatusWitheld(TwStreaming sender, StatusWitheldEvent @event);
    internal delegate void StreamingEventUserWitheld(TwStreaming sender, UserWithheldEvent @event);
    internal delegate void StreamingEventDisconnected(TwStreaming sender, DisconnectEvent @event);

    internal delegate void StreamingEventStallWarning(TwStreaming sender, WarningEvent @event);
    internal delegate void StreamingEventTooManyFollowsWarning(TwStreaming sender, WarningEvent @event);
    
    internal delegate void StreamingEventFriends(TwStreaming sender, FriendsEvent @event);
    internal delegate void StreamingEventFriendsStr(TwStreaming sender, FriendsStrEvent @event);

    internal delegate void StreamingEventUserUpdate(TwStreaming sender, UserUpdateEvents @event);
    internal delegate void StreamingEventUserDeauthorizesStream(TwStreaming sender, UserDeauthorizesStreamEvent @event);
    internal delegate void StreamingEventBlock(TwStreaming sender, BlockEvent @event);
    internal delegate void StreamingEventUnblock(TwStreaming sender, UnblockEvent @event);


}
