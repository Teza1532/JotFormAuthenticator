using DataAnalysis.DbContexts;
using DataAnalysis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysis.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext FormDBContext)
        {
            _context = FormDBContext;
        }

        public List<Job> GetJobs()
        {
            return _context.Jobs.ToList();
        }

        public List<Vehicle> GetVehicles()
        {
            return _context.Vehicles
                .Include(v => v.Jobs)
                .ToList();
        }

        public List<Department> GetDepartments()
        {
            return _context.Departments
            .Include(d => d.Jobs)
            .ToList();
        }

        public List<Job> GetVehicleJobs(string VehicleID)
        {
            return _context.Jobs
                .Where(j => j.VehicleID == VehicleID)
                .ToList();
        }

    }
}


