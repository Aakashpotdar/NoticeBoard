using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Manager
{
    public class UserManager:IUserManager
    {
        public async Task<IActionResult> login(UserModel email, UserModel password)
        {

        }
 
    }
}
