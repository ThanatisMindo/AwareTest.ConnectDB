using AwareTest.ModelNew.Model;
using SPWCircularofLux.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.DataAccess.IRepositories
{
    public interface ITerritoriesRepository : IRepository<TerritoriesModel>
    {
        Task<TerritoriesModel?> GetWithIncludeAllByIdAsync(long id);
        Task<TerritoriesModel?> GetWithIncludeAllByRegionIDAsync(int regionID);
    }
}
