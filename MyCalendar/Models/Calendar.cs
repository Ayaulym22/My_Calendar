using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Calendar
    {

        [Key]

        public int Calendar_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Month is Required")]
        public int Month { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Year is Required")]
        public int Year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Day is Required")]
        public int Day { get; set; }

        public int? Event_id { get; set; }
        public Event Event { get; set; }

        public int? Task_id { get; set; }
        public Task Task { get; set; }
    }
}