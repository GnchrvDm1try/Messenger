using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Messenger.Models;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        readonly MessageContext context = new MessageContext();
        readonly string Username = System.Web.HttpContext.Current.User.Identity.Name;
        public ActionResult Index(string chatUsername)
        {
            User user = new User();
            User chatUser = new User();
            List<User> users = new List<User>();
            List<Message> lastMessages = new List<Message>();


            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                user = context.Users.FirstOrDefault(u => u.UserName == Username);
                chatUser = context.Users.FirstOrDefault(u => u.UserName == chatUsername);
                users = context.Users.Where(u => u.UserName != null && u.UserName != user.UserName).ToList();
                List<Message> messages = context.Messages.Where(m => m.Receiver == user.UserName && m.Sender == chatUsername || m.Receiver == chatUsername && m.Sender == user.UserName).ToList();
                ViewBag.Messages = messages;

                Message mmmm = new Message();
                foreach(User usr in users)
                {
                    mmmm = context.Messages.Where(m => m.Sender == usr.UserName && m.Receiver == Username || m.Receiver == usr.UserName && m.Sender == Username)
                        .OrderByDescending(m => m.Time)
                        .ToList()
                        .FirstOrDefault();
                    if(mmmm != null)
                        lastMessages.Add(mmmm);
                }
            }
            ViewBag.LastMessages = lastMessages;
            ViewBag.Users = users;
            ViewBag.ChatUser = chatUser;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Messenger application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us here.";

            return View();
        }

        public string Logout()
        {
            string name = System.Web.HttpContext.Current.User.Identity.Name;
            FormsAuthentication.SignOut();
            return $"Вы вышли из учётной записи \"{name}\"";
        }

        public void SendMessage(string reciever, string sender, string content)
        {
            context.Messages.Add(new Message()
            {
                ID = context.Messages.Count() + 1,
                Content = content,
                Sender = sender,
                Receiver = reciever,
                Time = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}