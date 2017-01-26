using System.Runtime.Serialization;

namespace Limitation.Twitter.TimeLine
{
    [DataContract]
    internal enum TimeLineTypes
    {
        [EnumMember(Value = "home")]
        Home,

        [EnumMember(Value = "mention")]
        Mention,

        [EnumMember(Value = "dm")]
        DM,

        [EnumMember(Value = "bio")]
        Bio,

        [EnumMember(Value = "follower")]
        Follower,

        [EnumMember(Value = "following")]
        Following,

        [EnumMember(Value = "favorite")]
        Favorite,

        [EnumMember(Value = "list")]
        List,

        [EnumMember(Value = "search")]
        Search
    }
}
