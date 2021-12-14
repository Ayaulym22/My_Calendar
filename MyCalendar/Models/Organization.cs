using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Organization
    {
        [Key]
        public int Org_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Organizatio Name is Required")]
        public string Org_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Information about the organization is Required")]
        public string Org_information { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name of organizer is Required")]
        public string Name_organizer { get; set; }
    }
}