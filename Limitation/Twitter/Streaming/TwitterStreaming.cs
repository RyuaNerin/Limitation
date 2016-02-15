using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Linq;
using Limitation.Setting.Objects;

namespace Limitation.Twitter.Streaming.Model
{
    internal class TwitterStreaming
    {
        // All User | All Replies | No Followings
        private const string StreamingUri = "https://userstream.twitter.com/1.1/user.json?with=user&replies=all&stringify_friend_ids=false";

        public TwitterStreaming(Profile profile)
        {
            this.Profile = profile;
        }
        
        public event OnStreamingConnected OnStreamingConnected;
        public event OnStreamingError OnStreamingError;
        public event OnStreamingDisconnected OnStreamingDisconnected;

        public event OnDelete OnDelete;
        public event OnScrubGeo OnScrubGeo;
        public event OnLimit OnLimit;
        public event OnStatusWithheld OnStatusWithheld;
        public event OnUserWithheld OnUserWithheld;
        public event OnDisconnected OnDisconnected;

        public event OnStallWarning OnStallWarning;
        public event OnTooManyFollowsWarning OnTooManyFollowsWarning;

        public event OnFriends OnFriends;

        public event OnUserUpdate OnUserUpdate;
        public event OnUserDeauthorizesStream OnUserDeauthorizesStream;
        public event OnBlock OnBlock;
        public event OnUnblock OnUnblock;
        public event OnFavorite OnFavorite;
        public event OnUnfavorite OnUnfavorite;
        public event OnFollow OnFollow;
        public event OnUnfollow OnUnfollow;
        public event OnListCreated OnListCreated;
        public event OnListDestroyed OnListDestroyed;
        public event OnListUpdated OnListUpdated;
        public event OnListMemberAdded OnListMemberAdded;
        public event OnListMemberRemoved OnListMemberRemoved;
        public event OnListUserSubscribed OnListUserSubscribed;
        public event OnListUserUnsubscribed OnListUserUnsubscribed;
        public event OnQuotedTweet OnQuotedTweet;

        public event OnStatusUpdated OnStatusUpdated;

        public bool StremaingConnected { get { return this.m_task != null && this.m_task.Status == TaskStatus.Running; } }
        
        public Profile Profile { get; private set; }

        private WebRequest m_request;
        private WebResponse m_response;
        private Task m_task;

        public void ConnectStreaming()
        {
            this.m_request = this.Profile.OAuth.CreateWebRequest("GET", TwitterStreaming.StreamingUri) as HttpWebRequest;
            this.m_task = Task.Factory.StartNew(this.Streaming);
        }

        public void CloseStreaming()
        {            
            if (this.StremaingConnected)
            {
                try
                {
                    this.m_response.Close();
                    this.m_response.Dispose();
                }
                catch
                { }

                this.m_task.Wait();
            }
        }

        private void Streaming()
        {
            try
            {
                this.m_response = this.m_request.GetResponse() as HttpWebResponse;

                using (var reader = new StreamReader(this.m_response.GetResponseStream()))
                {
                    if (this.OnStreamingConnected != null) this.OnStreamingConnected.Invoke(this);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        this.HandleMessage(line);
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectionClosed)
                    return;

                if (this.OnStreamingError != null) this.OnStreamingError.Invoke(this, ex);
            }

            if (this.OnStreamingDisconnected != null) this.OnStreamingDisconnected.Invoke(this);
        }

        //////////////////////////////////////////////////
        // ㅎㅎ
        [DataContract]
        private class EventParser
        {
            [DataMember(Name = "delete")]
            public Delete Delete { get; set; }

            [DataMember(Name = "disconnect")]
            public Disconnect Disconnect { get; set; }

            [DataMember(Name = "friends")]
            public long[] Friends { get; set; }

            [DataMember(Name = "friends_str")]
            public string[] FriendsStr { get; set; }

            [DataMember(Name = "limit")]
            public Limit Limit { get; set; }

            [DataMember(Name = "scrub_geo")]
            public ScrubGeo ScrubGeo { get; set; }

            [DataMember(Name = "status_withheld")]
            public StatusWithheld StatusWithheld { get; set; }

            [DataMember(Name = "user_withheld")]
            public UserWithheld UserWithheld { get; set; }

            [DataMember(Name = "event")]
            public string Event { get; set; }

            [DataMember(Name = "warning")]
            public Warning Warning { get; set; }
        }

        private void HandleMessage(string body)
        {
            var parser = Utilities.ParseJsonObject<EventParser>(body);
            if (parser == null) return;

            if (parser.Delete         != null && this.OnDelete         != null) { this.OnDelete        .Invoke(this, parser.Delete);         return; }
            if (parser.Disconnect     != null && this.OnDisconnected   != null) { this.OnDisconnected  .Invoke(this, parser.Disconnect);     return; }
            if (parser.Friends        != null && this.OnFriends        != null) { this.OnFriends       .Invoke(this, parser.Friends);        return; }
            if (parser.Limit          != null && this.OnLimit          != null) { this.OnLimit         .Invoke(this, parser.Limit);          return; }
            if (parser.ScrubGeo       != null && this.OnScrubGeo       != null) { this.OnScrubGeo      .Invoke(this, parser.ScrubGeo);       return; }
            if (parser.StatusWithheld != null && this.OnStatusWithheld != null) { this.OnStatusWithheld.Invoke(this, parser.StatusWithheld); return; }
            if (parser.UserWithheld   != null && this.OnUserWithheld   != null) { this.OnUserWithheld  .Invoke(this, parser.UserWithheld);   return; }

            if (parser.Warning != null) { this.HandleMessage(parser.Warning, body); return; }
            if (parser.Event   != null) { this.HandleMessage(parser.Event,   body); return; }
        }

        private void HandleMessage(string @event, string body)
        {
            // SO SEXY CODE
            switch (@event)
            {
                case "access_revoked":          if (this.OnUserDeauthorizesStream   != null) this.OnUserDeauthorizesStream.Invoke(this, Utilities.ParseJsonObject<UserDeauthorizesStream>(body)); return;
                case "block":                   if (this.OnBlock                    != null) this.OnBlock                 .Invoke(this, Utilities.ParseJsonObject<Block                 >(body)); return;
                case "unblock":                 if (this.OnUnblock                  != null) this.OnUnblock               .Invoke(this, Utilities.ParseJsonObject<Unblock               >(body)); return;
                case "favorite":                if (this.OnFavorite                 != null) this.OnFavorite              .Invoke(this, Utilities.ParseJsonObject<Favorite              >(body)); return;
                case "unfavorite":              if (this.OnUnfavorite               != null) this.OnUnfavorite            .Invoke(this, Utilities.ParseJsonObject<Unfavorite            >(body)); return;
                case "follow":                  if (this.OnFollow                   != null) this.OnFollow                .Invoke(this, Utilities.ParseJsonObject<Follow                >(body)); return;
                case "unfollow":                if (this.OnUnfollow                 != null) this.OnUnfollow              .Invoke(this, Utilities.ParseJsonObject<Unfollow              >(body)); return;
                case "list_created":            if (this.OnListCreated              != null) this.OnListCreated           .Invoke(this, Utilities.ParseJsonObject<ListCreated           >(body)); return;
                case "list_destroyed":          if (this.OnListDestroyed            != null) this.OnListDestroyed         .Invoke(this, Utilities.ParseJsonObject<ListDestroyed         >(body)); return;
                case "list_updated":            if (this.OnListUpdated              != null) this.OnListUpdated           .Invoke(this, Utilities.ParseJsonObject<ListUpdated           >(body)); return;
                case "list_member_added":       if (this.OnListMemberAdded          != null) this.OnListMemberAdded       .Invoke(this, Utilities.ParseJsonObject<ListMemberAdded       >(body)); return;
                case "list_member_removed":     if (this.OnListMemberRemoved        != null) this.OnListMemberRemoved     .Invoke(this, Utilities.ParseJsonObject<ListMemberRemoved     >(body)); return;
                case "list_user_subscribed":    if (this.OnListUserSubscribed       != null) this.OnListUserSubscribed    .Invoke(this, Utilities.ParseJsonObject<ListUserSubscribed    >(body)); return;
                case "list_user_unsubscribed":  if (this.OnListUserUnsubscribed     != null) this.OnListUserUnsubscribed  .Invoke(this, Utilities.ParseJsonObject<ListUserUnsubscribed  >(body)); return;
                case "quoted_tweet":            if (this.OnQuotedTweet              != null) this.OnQuotedTweet           .Invoke(this, Utilities.ParseJsonObject<QuotedTweet           >(body)); return;
                case "user_update":             if (this.OnListUpdated              != null) this.OnListUpdated           .Invoke(this, Utilities.ParseJsonObject<ListUpdated           >(body)); return;
            }
        }

        private void HandleMessage(Warning warning, string body)
        {
            switch (warning.Code)
            {
                case "FALLING_BEHIND":          if (this.OnStallWarning             != null) this.OnStallWarning         .Invoke(this, Utilities.ParseJsonObject<StallWarning           >(body)); return;
                case "FOLLOWS_OVER_LIMIT":      if (this.OnTooManyFollowsWarning    != null) this.OnTooManyFollowsWarning.Invoke(this, Utilities.ParseJsonObject<TooManyFollowsWarning  >(body)); return;
            }
        }

    }
}
