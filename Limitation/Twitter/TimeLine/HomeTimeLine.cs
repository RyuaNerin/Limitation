using System;
using Limitation.Setting;
using Limitation.Setting.Objects;
using Limitation.Twitter;
using Limitation.Twitter.BaseModel;

namespace Limitation.Twitter.TimeLine
{
    internal class HomeTimeLine : BaseTimeLine
    {
        public HomeTimeLine(Profile profile)
            : base(profile)
        { }

        public override TimeLineTypes TimeLineType => TimeLineTypes.Home;

        protected override void UpdatePriv()
        {
            Uri uri;

            if (this.MaxId.HasValue)
                uri = new Uri($"https://api.twitter.com/1.1/statuses/home_timeline.json?include_entities=true&count={Options.Instance.TweetsLoadCount}&since_id={this.MaxId.Value}");
            else
                uri = new Uri($"https://api.twitter.com/1.1/statuses/home_timeline.json?include_entities=true&count={Options.Instance.TweetsLoadCount}");

            var str = this.Profile.OAuth.GetResponse("GET", uri);

            this.Add(str.ParseJsonArray<BaseStatus>());
        }
    }
}
