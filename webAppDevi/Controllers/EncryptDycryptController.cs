using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webAppDevi.Models;
using webAppDevi.Common;

namespace webAppDevi.Controllers
{
    public class EncryptDycryptController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            int enumNumber = Convert.ToInt32(frm["EncryptDecryptOption"]);
            
            if (EnumHelper.EncryptDecrypt.Encrypt.GetHashCode() == enumNumber)
            {
                TempData["EncryptDecryptKey"] = EncryptDycrypt.Encrypt(frm["EncryptDecrypt"]);
            }
            else if (EnumHelper.EncryptDecrypt.Decrypt.GetHashCode() == enumNumber)
            {
                TempData["EncryptDecryptKey"] = EncryptDycrypt.Decrypt(frm["EncryptDecrypt"]);
            }
            return View();
        }
    }
}
