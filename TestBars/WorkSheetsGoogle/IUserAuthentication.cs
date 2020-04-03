using Google.Apis.Auth.OAuth2;

namespace TestBars.WorkSheetsGoogle
{
    public interface IUserAuthentication
    {
        UserCredential Authentication();
    }
}
