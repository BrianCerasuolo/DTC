using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetroitTradingMvcTest.Models
{
    public class Vehicle
    {
        [Required]
        public VehicleMake Make { get; set; }
        [Required]
        public VehicleModel Model { get; set; }
    }
}