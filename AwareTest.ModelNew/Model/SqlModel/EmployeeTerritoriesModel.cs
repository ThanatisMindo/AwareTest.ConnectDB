using AwareTest.ModelNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.ModelNew.Model
{
    public class EmployeeTerritoriesModel
    {
        public int EmployeeID { get; set; }
        public int TerritoryID { get; set; }

        public EmployeeModel Employee { get; set; }
        public TerritoriesModel Territory { get; set; }
    }
}
