using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    /// <summary>
    /// User manager class
    /// </summary>
    public class UserManager:IUserManager
    {
        /// <summary>
        /// user manager instance
        /// </summary>
        public readonly IUserRepository userRepo;

        /// <summary>
        /// constructor for user manager
        /// </summary>
        public UserManager(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        /// <summary>
        /// login method
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task login(string email, string password)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<Boolean> register(UserModel userModel)
        {
            try
            {
                await userRepo.register(userModel);
            }
            catch (Exception e)
            {
                //console.log("error in register user: ", e.Message);
            }
            return true;
        }


    }
}
