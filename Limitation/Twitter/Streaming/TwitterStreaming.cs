using System.IO;
using System.Net;
using System.Threading.Tasks;
using Limitation.Setting.Objects;

namespace Limitation.Twitter.Streaming
{
    internal class TwitterStreaming
    {
        // All User | All Replies | No Followings
        private const string StreamingUri = "https://userstream.twitter.com/1.1/user.json?with=user&replies=all&stringify_friend_ids=false";

        public TwitterStreaming(Profile profile)
        {
            this.Profile = profile;
        }

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
                    if (this.OnConnected != null) this.OnConnected.Invoke(this);

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectionClosed)
                    return;

                if (this.OnError != null) this.OnError.Invoke(this, ex);
            }

            if (this.OnDisconnected != null) this.OnDisconnected.Invoke(this);
        }
    }
}
