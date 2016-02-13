using System.Net;
using System.ComponentModel;

namespace Limitation.Setting.Objects
{    
    internal class Proxy
    {
        [SettingAttr]
        [DefaultValue(true)]
        public bool UseProxy { get; set; }

        [SettingAttr]
        [DefaultValue(true)]
        public bool UseSystem { get; set; }

        [SettingAttr]
        [DefaultValue(null)]
        public string Host { get; set; }

        [SettingAttr]
        [DefaultValue(80)]
        public int Port { get; set; }

        [SettingAttr]
        [DefaultValue(null)]
        public string Id { get; set; }

        [SettingAttr]
        [DefaultValue(null)]
        public string Password { get; set; }

        public void SetProxy()
        {
            if (!UseProxy)
            {
                HttpWebRequest.DefaultWebProxy = null;
            }
            else
            {
                if (UseProxy)
                    HttpWebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();
                else
                {
                    var proxy = new WebProxy(this.Host, this.Port);
                    if (!string.IsNullOrWhiteSpace(this.Id))
                        proxy.Credentials = new NetworkCredential(this.Id, this.Password);

                    HttpWebRequest.DefaultWebProxy = proxy;
                }
            }
        }
    }
}
