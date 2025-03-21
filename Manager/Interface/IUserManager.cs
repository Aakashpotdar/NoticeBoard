using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface IUserManager
    {
        public Task<IActionResult> login(UserModel email, UserModel password);
    }
}
