using Model.Interface;
using Model.Model;
using MongoDB.Driver;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    /// <summary>
    /// class for user repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// user model object
        /// </summary>
        public readonly IMongoCollection<UserModel> userInfoData;

        /// <summary>
        /// constructor for UserRepository
        /// </summary>
        /// <param name="settings"></param>
        public UserRepository(INoticeBoardDBConnection settings)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var dataBase = client.GetDatabase("NoticBoardApp");
            this.userInfoData = dataBase.GetCollection<UserModel>("UserData");
        }

        /// <summary>
        /// login method
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task login(string email, string password)
        {

        }

        /// <summary>
        /// method to register the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task register(UserModel userModel)
        {
            this.userInfoData.InsertOneAsync(userModel);
        }
    }
}
