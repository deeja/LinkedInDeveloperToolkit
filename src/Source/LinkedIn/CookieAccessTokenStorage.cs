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
            PersistValue(token);
        }

        private void PersistValue(string value)
        {
            HttpCookie cookie = new HttpCookie(CookieName)
                                    {
                                        Value = Encrypt(value)
                                    };

            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        private string RetrieveValue()
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[CookieName];
            if (httpCookie == null) return null;
            return Decrypt(httpCookie.Value);
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
            string tokenString = RetrieveValue();

            if (string.IsNullOrWhiteSpace(tokenString))
            {
                throw new AccessTokenNotFoundException();
            }

            return tokenString;
        }
    }
}