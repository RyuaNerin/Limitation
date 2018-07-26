using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Limitation.Twitter.Model;

namespace Limitation.Windows.Controls
{
    [System.ComponentModel.DesignerCategory("CODE")]
    internal class TweetControl : Control
    {
        public Status TweetObject { get; private set; }

        public Status[] SubTweets { get; }
    }
}
