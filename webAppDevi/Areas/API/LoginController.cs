using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAppDevi.Common;
using webAppDevi.Models;

namespace webAppDevi.Areas.API
{
    public class LoginController : ApiController
    {
        Services s = new Services();
        #region "User"
        /// <summary>
        /// Get all Rater type users
        /// </summary>                
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        [CustomAuthorize]
        [Route("api/login/getuser")]
        [HttpGet]
        public User getUser(string username, string password)
        {
            User u = s.GetUserByUserNameOrEmailAndPassword(username, password);
            return u;
        }

        #endregion
    }
}
