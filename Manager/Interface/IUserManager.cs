using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface IUserManager
    {
        /// <summary>
        /// Interface for login method 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task login(string email, string password);

        /// <summary>
        /// Interface for the register the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public Task<bool> register(UserModel userModel);
    }
}
