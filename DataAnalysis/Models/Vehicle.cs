using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysis.Models
{
    public class Vehicle
    {
        [Key]
        public string VehicleID { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
