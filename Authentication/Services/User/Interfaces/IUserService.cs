using Microsoft.AspNetCore.DataProtection;

namespace Authentication.Services.User.Interfaces
{
    public interface IUserService
    {
        string GetUsername(string authCookie, IDataProtector protector);
    }
}
