using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;


using LibraryManagement.Services;
using System.Web.Script.Serialization;

namespace LibraryManagement.Controllers
{
    using LibraryManagement.Models;
    using LibraryManagement.ViewModels;
    using LibraryManagement.DAL.ViewModelTransalator;
    using Utilities;
    using LibraryManagement.Enums;

    [Authorize] 
    public class AccountController : Controller
    {
        private IViewModelTransalator<UserViewModel, UserModel> userViewModelTransalator = null;
        private IUserService userService = null;

        public AccountController(IUserService userService, IViewModelTransalator<UserViewModel, UserModel> userViewModelTransalator)
        {
            this.userViewModelTransalator = userViewModelTransalator;
            this.userService = userService;
        }

        [AllowAnonymous]
        public JsonResult Login()
        {
            string authorization = HttpContext.Request.Headers["Authorization"];
            string userInfo;
            string username = "";
            string password = "";
            if (authorization != null)
            {
                byte[] tempConverted = Convert.FromBase64String(authorization.Replace("Basic ", "").Trim());
                userInfo = System.Text.Encoding.UTF8.GetString(tempConverted);
                string[] usernamePassword = userInfo.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                username = usernamePassword[0];
                password = usernamePassword[1];

                //get the user info and 
                var userModel = userService.SelectByID(username);
                if (userModel != null)
                {
                    UserViewModel userViewModel = this.userViewModelTransalator.TransalateToViewModel(userModel);
                    if (username == userViewModel.UserName && password == userViewModel.Password)
                    {
                        return this.Json(new { userViewModel }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return this.Json(null, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return this.Json(null, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="formInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register(string formInfo)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var user = jss.Deserialize<UserModel>(formInfo);
            user.RoleId = RoleEnums.User;
            //save
            userService.Insert(user);
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}




