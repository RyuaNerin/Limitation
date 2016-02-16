using System.Net;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class Proxy
    {
        [DataMember(Name = "use_proxy")]
        [DefaultValue(true)]
        public bool UseProxy { get; set; }

        [DataMember(Name = "use_system")]
        [DefaultValue(true)]
        public bool UseSystem { get; set; }

        [DataMember(Name = "host")]
        [DefaultValue(null)]
        public string Host { get; set; }

        [DataMember(Name = "port")]
        [DefaultValue(80)]
        public int Port { get; set; }

        [DataMember(Name = "id")]
        [DefaultValue(null)]
        public string Id { get; set; }

        [DataMember(Name = "pw")]
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
