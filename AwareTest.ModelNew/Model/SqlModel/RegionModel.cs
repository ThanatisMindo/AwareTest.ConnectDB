using AwareTest.ModelNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.ModelNew.Model
{
    public class RegionModel
    {
        public int RegionID { get; set; }
        public string RegionDescription { get; set; } = string.Empty;
        public ICollection<TerritoriesModel> Territories { get; set; }
    }
}
