using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    /// <summary>
    /// interface for user repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// interface for login method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<Boolean> login(UserModel userModel);

        /// <summary>
        /// interface for register model   
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public Task register(UserModel userModel);

        /// <summary>
        /// genarte token method 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<string> GenrateToken(string email);
    }
}
