using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticeBoardApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserManager userManager; 
        public UserController(IUserManager userObj)
        {
            this.userManager = userObj;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel email, UserModel password)
        {
            try
            {
                var result = await userManager.login(email,password);

                return result;
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Status = true, Massage = "Unsuccessfully login" });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register()
        {

        }

        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword()
        {
        }

        [HttpPost]
        [Route("forgetpassword")]
        public async Task<IActionResult> ForgetPassword()
        {

        } 
    }
}
