using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitation.Twitter.Objects;

namespace Limitation.Twitter.Api
{
    internal static class ApiStatuses
    {
        public static StatusObject[] Statuses_HomeTimeLine(this OAuth oauth, bool? include_entities, int? count, long? since_id)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("https://api.twitter.com/1.1/statuses/mentions_timeline.json?");

                if (include_entities.HasValue)
                    sb.Append($"include_entities={include_entities.Value}&");

                if (count.HasValue)
                    sb.Append($"count={count.Value}&");

                if (since_id.HasValue)
                    sb.Append($"since_id={since_id.Value}&");

                sb.Remove(sb.Length - 1, 1);

                return oauth.GetResponse("GET", new Uri(sb.ToString())).ParseJsonArray<StatusObject>();
            }
            catch
            {
                return null;
            }
        }
    }
}
