using System.Web;

namespace LinkedIn
{
    public class CookieAccessTokenStorage : IAccessTokenStorage
    {
        public const string CookieName = "AccessTokenStorage";

        public CookieAccessTokenStorage(string consumerSecret)
        {
            SharedSecret = consumerSecret;
        }

        public string SharedSecret { get; private set; }

        public void StoreToken(string token)
        {
            HttpCookie cookie = new HttpCookie(CookieName)
                                     {
                                         Value = Encrypt(token)
                                     };

            HttpContext.Current.Response.Cookies.Set(cookie);
        }

     
        private string Encrypt(string value)
        {
            return Crypto.EncryptStringAES(value, SharedSecret);
        }

        private string Decrypt(string value)
        {
            return Crypto.DecryptStringAES(value, SharedSecret);
        }


        public string GetToken()
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
            if (httpCookie == null)
            {
                throw new AccessTokenNotFoundException();
            }

            var tokenString =  Decrypt(httpCookie.Value);

            if (string.IsNullOrWhiteSpace(tokenString))
            {
                throw new AccessTokenNotFoundException();
            }

            return tokenString;
        }
    }
}