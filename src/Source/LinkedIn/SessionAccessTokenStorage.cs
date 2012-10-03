using System.Web;

namespace LinkedIn
{
    public class SessionAccessTokenStorage : IAccessTokenStorage
    {
        public void StoreToken(string token)
        {
            HttpContext.Current.Session[AccessTokenKey] = token;
        }

        protected string AccessTokenKey = "access-token";


        public string GetToken()
        {
            var token = HttpContext.Current.Session[AccessTokenKey];
            if (token == null) return null;
            return (string) token;
        }
    }
}