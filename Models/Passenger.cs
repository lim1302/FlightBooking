using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UkraineAirline.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "IC")]
        public string IC { get; set; }
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Phone No.")]
        public int Phone { get; set; }
    }
}
