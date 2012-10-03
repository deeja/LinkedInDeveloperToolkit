namespace LinkedIn
{
    public interface IAccessTokenStorage
    {
        void StoreToken(string token);
        string GetToken();
    }
}