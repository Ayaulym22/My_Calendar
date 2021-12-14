using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Task
    {
        [Key]
        public int Task_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Task Name is Required")]
        public string Task_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Deadline is Required")]
        public string Deadline { get; set; }

        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public bool Completed { get; set; }

        public int? Category_Id { get; set; }
        public CategoryTask CategoryTask { get; set; }
        public int? Notify_Id { get; set; }
        public Notification Notification { get; set; }
    }
}