﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnalysis.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

    }
}