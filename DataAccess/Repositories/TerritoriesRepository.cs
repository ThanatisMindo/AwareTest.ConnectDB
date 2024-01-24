using AwareTest.DataAccess.IRepositories;
using AwareTest.ModelNew.Model;
using SPWCircularofLux.Data.Repositories;
using SPWCircularofLux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AwareTest.DataAccess.Repositories
{
    public class TerritoriesRepository : Repository<TerritoriesModel>, ITerritoriesRepository
    {
        private AwareServiceDbContext _dbContext
        {
            get { return Context as AwareServiceDbContext; }
        }
        public TerritoriesRepository(AwareServiceDbContext context) : base(context)
        { }

        public async Task<TerritoriesModel?> GetWithIncludeAllByIdAsync(long id)
        {
            return await _dbContext.Territories
                .FirstOrDefaultAsync(m => m.TerritoryID == id);
        }

        public async Task<TerritoriesModel?> GetWithIncludeAllByRegionIDAsync(int regionID)
        {
            return await _dbContext.Territories
                .FirstOrDefaultAsync(m => m.RegionID == regionID);
        }
    }
}
