using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class AccountController : Controller
    {
        MessageContext messageContext = new MessageContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = messageContext.Users.FirstOrDefault(u => u.UserName == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = messageContext.Users.FirstOrDefault(u => u.UserName == model.Name);
                if (user == null)
                {
                    messageContext.Users.Add(
                        new Models.User
                        {
                            UserName = model.Name,
                            Password = model.Password,
                            ProfilePhoto = model.ProfilePhoto,
                            Email = model.Email,
                            UserBirthDate = model.BitrhDate
                        });
                    messageContext.SaveChanges();
                    user = messageContext.Users.Where(u => u.UserName == model.Name && u.Password == model.Password).FirstOrDefault();
                    if (User != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
    }
}