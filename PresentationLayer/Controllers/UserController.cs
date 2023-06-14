using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        CETRepo repo = new CETRepo();
        CETDBContext db = new CETDBContext();
        // GET: User
        [HttpGet]
        public ActionResult AuthenticateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthenticateUser(UserModel details) 
        {
            User_Details user = repo.ValidateUser(details.User_EmailId, details.User_Password);
            if(user == null)
            {
                ViewBag.msg = "Invalid user or password";
                return View();
            }
            else
            {
                Session["emailid"] = details.User_EmailId;
                Session["userid"] = user.User_ID;
                return RedirectToAction("ListAllEmployee","CET");
            }
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserModel ud)
        {
            if(ModelState.IsValid)
            {
                DataAccessLayer.User_Details res = new DataAccessLayer.User_Details()
                {
                    User_ID = ud.User_ID,
                    User_First_Name = ud.User_First_Name,
                    User_Last_Name = ud.User_Last_Name,
                    User_EmailId = ud.User_EmailId,
                    User_Password = ud.User_Password,
                };

                bool result = repo.RegisterUser(res);
                if (!result)
                {
                    return View("Error");
                }
            }
            return RedirectToAction("AuthenticateUser");
        }
    }
}