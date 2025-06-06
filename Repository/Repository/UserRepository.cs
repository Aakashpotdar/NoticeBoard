using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Interface;
using Model.Model;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public readonly IConfiguration configuration;

        /// <summary>
        /// constructor for UserRepository
        /// </summary>
        /// <param name="settings"></param>
        public UserRepository(INoticeBoardDBConnection settings, IConfiguration configuration)
        {
            this.configuration = configuration;

            var client = new MongoClient("mongodb://127.0.0.1:27017/");
            var dataBase = client.GetDatabase("NoticBoardApp");
            this.userInfoData = dataBase.GetCollection<UserModel>("UserData");
        }

        /// <summary>
        /// login method
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Boolean> login(UserModel userModel)
        {
            try
            {
                var checkPassword = await this.userInfoData.AsQueryable().Where(a => a.password == userModel.password).FirstOrDefaultAsync();
                if(checkPassword == null)
                {
                    return false;
                }
                if (userModel.email != null && userModel.password != null)
                {
                    //var checkEmail = await this.userInfoData.FindAsync(userModel.email);
                    var checkEmail1 = await this.userInfoData.AsQueryable().Where(a => a.email == userModel.email).FirstOrDefaultAsync();

                    if (checkEmail1 != null)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(message:ex.Message);
            }
        }

        /// <summary>
        /// method to register the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task register(UserModel userModel)
        {
            try 
            {
                await this.userInfoData.InsertOneAsync(userModel);
            }
            catch(Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

        /// <summary>
        /// genrates token
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<string> GenrateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.configuration["Jwt:SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor {

                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
