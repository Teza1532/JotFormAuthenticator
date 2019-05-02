using DataAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysis.Repositories
{
   public  interface IVehicleRepository
    {
        List<Department> GetDepartments();
    }
}
