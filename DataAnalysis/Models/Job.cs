using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysis.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobNo { get; set; }
        public string JobDate { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public decimal CostOfParts { get; set; }
        public decimal CostOfLabour { get; set; }
        public decimal OverAllCost { get; set; }

        public string VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
