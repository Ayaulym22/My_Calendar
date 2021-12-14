using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Name is Required.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int? Event_id { get; set; }
        public Event Event { get; set; }

        public int? Task_id { get; set; }
        public Task Task { get; set; }

        public int? Calendar_id { get; set; }
        public Calendar Calendar { get; set; }
    }
}