using Microsoft.AspNetCore.Identity;
using WebApiStart.Data;
using WebApiStart.Models;

namespace WebApiStart.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> SignInAsync(SignInModel signInModel);
    }
}
