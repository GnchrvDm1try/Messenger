using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class User
    {
        [Key]
        public string UserName {get; set; }
        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public string Email { get; set; }
        public DateTime UserBirthDate { get; set; }
    }
}