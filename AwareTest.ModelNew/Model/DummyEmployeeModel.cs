﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.ModelNew.Model
{
    public class DummyEmployeeModel
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public double employee_age { get; set; }
        public string profile_image { get; set; }
        
    }
    public class ApiResponseModel
    {
        public string Status { get; set; }
        public List<DummyEmployeeModel> Data { get; set; }
        public string Message { get; set; }
    }
}
