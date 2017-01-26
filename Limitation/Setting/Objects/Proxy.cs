using System.Net;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Limitation.Setting.Objects
{
    [DataContract]
    internal class Proxy
    {
        [DataMember(Name = "proxy_type")]
        [DefaultValue(ProxyTypes.None)]
        public ProxyTypes ProxyType { get; set; }

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
            if (this.ProxyType == ProxyTypes.None)
            {
                HttpWebRequest.DefaultWebProxy = null;
            }
            else
            {
                if (this.ProxyType == ProxyTypes.System)
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

    [DataContract]
    public enum ProxyTypes
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "system")]
        System,

        [EnumMember(Value = "Manual")]
        Manual
    }
}
