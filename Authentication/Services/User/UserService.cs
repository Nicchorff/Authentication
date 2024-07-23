using Authentication.Services.User.Interfaces;
using Microsoft.AspNetCore.DataProtection;

namespace Authentication.Services.User
{
    public class UserService : IUserService
    {   
        public UserService() { }

        public string GetUsername(string authCookie, IDataProtector protector)
        {
            var protectedPayload = authCookie.Split('=').Last();
            var payload = protector.Unprotect(protectedPayload);
            var parts = payload.Split(':');
            var username = parts[1];
            return username;
        }
    }
}
