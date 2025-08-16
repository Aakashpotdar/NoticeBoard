using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System;
using System.Threading.Tasks;

namespace Manager.Interface
{
    public interface IUserManager
    {
        /// <summary>
        /// Interface for login method 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public Task<Boolean> login(UserModel userModel);

        /// <summary>
        /// Interface for the register the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public Task<bool> register(UserModel userModel);

        public Task<string> GenrateToken(string email);
    }
}
