using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    /// <summary>
    /// This interface we use for working with Identity provider
    /// </summary>
    public interface IUserService : IIdentityService
    {
        Task<SignInResult> SignInAsync(SignInModel model);
        Task SignOutAsync();
        Task<IdentityResult> SignUpAsync(SignUpModel model);
    }
}