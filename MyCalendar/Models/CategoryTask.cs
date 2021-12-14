using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class CategoryTask
    {

        [Key]
        public int Category_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name is Required")]
        public string Name { get; set; }
    }
}