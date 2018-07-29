using Limitation.Twitter.BaseModel;
using PropertyChanged;

namespace Limitation.Twitter.Objects
{
    internal class UserObject : BaseUser
    {
        [DependsOn("ScreenName", "Name")]
        public string MixedName => $"{this.Name} (@{this.ScreenName})";
    }
}
