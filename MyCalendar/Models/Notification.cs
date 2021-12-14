using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Notification
    {

        [Key]
        public int Notify_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Notification Date is Required")]
        public string Notify_date { get; set; }

    }
}

