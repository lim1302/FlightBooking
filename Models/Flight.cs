using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UkraineAirline.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        [Display(Name = "Flight No")]
        public string FlightNo { get; set; }
        [Display(Name = "Flight Origin")]
        public string Origin { get; set; }
        [Display(Name = "Flight Destination")]
        public string Destination { get; set; }
        [Display(Name = "Flight Departure")]
        public DateTime Departure { get; set; }
        [Display(Name = "Flight Arrival")]
        public DateTime Arrival { get; set; }
    }
}
