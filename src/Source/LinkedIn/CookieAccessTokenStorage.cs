using System.Web;

namespace LinkedIn
{
    public class CookieAccessTokenStorage : IAccessTokenStorage
    {
        public const string LinkedInKey = "LinkedInAccessToken";
        public void StoreToken(string token)
        {
            HttpContext.Current.Response.Cookies.Set(new HttpCookie(LinkedInKey,token));
        }

        public string GetToken()
        {
            var cookie = HttpContext.Current.Request.Cookies[LinkedInKey];

            if (cookie == null)
            {
                throw new AccessTokenNotFoundException();
            }

            string tokenString = cookie.Value;

            if (string.IsNullOrWhiteSpace(tokenString))
            {
                throw new AccessTokenNotFoundException();
            }

            return tokenString;
        }
    }
}