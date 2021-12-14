using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Event
    {

        [Key]
        public int Event_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Subject Name is Required")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Start time is Required")]
        public DateTime Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "End time is Required")]
        public DateTime End { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Color is Required")]
        public string TherneColor { get; set; }
        public bool IsFullDay { get; set; }
        public int? Org_id { get; set; }
        public Organization Organization { get; set; }

        public int? Notify_id { get; set; }
        public Notification Notification { get; set; }
    }
}