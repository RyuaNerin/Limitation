using System;
using System.Text.RegularExpressions;

namespace Limitation.Twitter.Api
{
    internal static class ApiOAuth
    {
        public static TokenPair Oauth_RequestToken(this OAuth oauth)
        {
            try
            {
                var obj = new { oauth_callback = "oob" };
                var str = oauth.GetResponse("POST", new Uri("https://api.twitter.com/oauth/request_token"), obj);

                return new TokenPair
                {
                    Token  = Regex.Match(str, @"oauth_token=([^&]+)").Groups[1].Value,
                    Secret = Regex.Match(str, @"oauth_token_secret=([^&]+)").Groups[1].Value
                };
            }
            catch
            {
                return null;
            }
        }

        public static TokenPair Oauth_AccessToken(this OAuth oauth, string verifier)
        {
            try
            {
                var obj = new { oauth_verifier = verifier };
                var str = oauth.GetResponse("POST", new Uri("https://api.twitter.com/oauth/access_token"), obj);

                var token = new TokenPair
                {
                    Token  = Regex.Match(str, @"oauth_token=([^&]+)").Groups[1].Value,
                    Secret = Regex.Match(str, @"oauth_token_secret=([^&]+)").Groups[1].Value
                };

                return token;
            }
            catch
            {
                return null;
            }
        }
    }
}
