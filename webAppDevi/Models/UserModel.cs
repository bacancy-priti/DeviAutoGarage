using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webAppDevi.Models
{
    public class UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        public string Password { get; set; }
    }
}