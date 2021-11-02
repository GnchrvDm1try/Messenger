using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Messenger.Models
{
    public class DBInitializer : CreateDatabaseIfNotExists<MessageContext>
    {
        protected override void Seed(MessageContext context)
        {
            context.Users.Add(
                new User()
                {
                    UserName = "Admin",
                    Password = "admin",
                    ProfilePhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQL2AHXE3hW6vGddO50sfiRGStV49pEGJVwKA&usqp=CAU",
                    Email = "Prototype1357@ukr.net",
                    UserBirthDate = new DateTime(1990, 5, 23)
                });
            context.Users.Add(
                new User()
                {
                    UserName = "Tester",
                    Password = "tester",
                    ProfilePhoto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSv1m3j7SVrPODWEsW7pgzWQRIQLNU1JV9K-g&usqp=CAU",
                    Email = "TesterEMail@gmail.com",
                    UserBirthDate = new DateTime(2000, 1, 12)
                });
            context.Messages.Add(
                new Message()
                {
                    ID = 1,
                    Content = "privet",
                    Sender = "Admin",//context.Users.Find("Admin"),
                    Receiver = "Tester",//context.Users.Find("Tester"),
                    Time = new DateTime(2021, 5, 31, 15, 56, 21)
                });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}