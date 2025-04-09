using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardApp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserManager userManager;
        public readonly ILogger<UserController> logger;

        public UserController(IUserManager userObj, ILogger<UserController> logger)
        {
            this.userManager = userObj;
            this.logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task Login([FromBody] UserModel userModel)
        {
            try
            {
                this.logger.LogInformation("the user {email} is trying to login!!",userModel.email);
                if (!string.IsNullOrEmpty(userModel.email) && !string.IsNullOrEmpty(userModel.password))
                {
                    await userManager.login(userModel.email, userModel.password);
                }
                else
                {
                    this.BadRequest(new { Status = true, Massage = "Give inputs Email and Password" });
                }
            }
            catch (Exception ex)
            {
                this.BadRequest(new { Status = true, Massage = "Unsuccessfully login" + ex.Message });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<Boolean> Register([FromBody]UserModel userModel)
        {
            try
            {
                if (userModel != null && !string.IsNullOrEmpty(userModel.email) && !string.IsNullOrEmpty(userModel.password))
                {
                    return await userManager.register(userModel);
                }
                else
                {
                    this.BadRequest(new { StatusCode = 400, Message = "Bad request" });
                }
            }
            catch (Exception ex)
            {
                this.BadRequest(new { Status = true, Message = "Not register due to error :" + ex.Message });
            }
            return true;
        }

        //[HttpPost]
        //[Route("resetpassword")]
        //public async Task<IActionResult> ResetPassword()
        //{
        //}

        //[HttpPost]
        //[Route("forgetpassword")]
        //public async Task<IActionResult> ForgetPassword()
        //{

        //} 
    }
}
