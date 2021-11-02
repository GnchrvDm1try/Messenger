using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Models
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Time { get; set; }
        //{ 
        //    get
        //    {
        //        return Time;
        //    }
        //    set
        //    {
        //        Time = DateTime.Now;
        //    }
        //}
    }
}