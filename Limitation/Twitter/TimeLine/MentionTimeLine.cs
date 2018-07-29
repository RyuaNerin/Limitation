using Limitation.Setting;
using Limitation.Setting.Objects;
using Limitation.Twitter.Api;

namespace Limitation.Twitter.TimeLine
{
    internal class MentionTimeLine : BaseTimeLine
    {
        public MentionTimeLine(Profile profile)
            : base(profile)
        { }

        public override TimeLineTypes TimeLineType => TimeLineTypes.Mention;

        protected override void UpdatePriv()
        {
            var arr = this.Profile.OAuth.Statuses_HomeTimeLine(
                include_entities: true,
                count           : Options.Instance.TweetsLoadCount,
                since_id        : this.MaxId);

            if (arr?.Length > 0)
                this.Add(arr);
        }
    }
}
