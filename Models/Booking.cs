using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UkraineAirline.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
        [Display(Name = "Flight")]
        public Flight Flight { get; set; }
        [Display(Name = "Passenger")]
        public Passenger Passenger { get; set; }
        [Display(Name = "User")]
        public ApplicationUser User { get; set; }
    }
}
