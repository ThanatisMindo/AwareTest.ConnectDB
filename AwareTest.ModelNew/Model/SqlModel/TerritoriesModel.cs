using AwareTest.ModelNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.ModelNew.Model
{
    public class TerritoriesModel
    {
        public int TerritoryID { get; set; }
        public string TerritoryDescription { get; set; } = string.Empty;
        public int RegionID { get; set;}
        public RegionModel Region { get; set; }
        public ICollection<EmployeeTerritoriesModel> EmployeeTerritories { get; set; } = new List<EmployeeTerritoriesModel>();
    }
}
