using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAnalysis.Models;
using DataAnalysis.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataAnalysis.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehicleController(IVehicleRepository Repository)
        {
            _repository = Repository;
        }

        [HttpGet("[action]")]
        public List<DepartmentsWithJobsCompleted> GetDepartmentJobsCount()
        {
            List<Department> departments = _repository.GetDepartments();
            List<DepartmentsWithJobsCompleted> dwjc = new List<DepartmentsWithJobsCompleted>();

            foreach ( Department d in departments )
            {
                dwjc.Add(new DepartmentsWithJobsCompleted(d.DepartmentID.ToString(), d.Jobs.Count));
            }

            return dwjc;
        }
    }

    public class DepartmentsWithJobsCompleted
    {

    public DepartmentsWithJobsCompleted(string departmentID, int jobsCompleted)
        {
            DepartmentID = departmentID;
            JobsCompleted = jobsCompleted;
        } 

    public string DepartmentID { get; set; }
        public int JobsCompleted { get; set; }
    }
}
