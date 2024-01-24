using System;
using AwareTest.DataAccess.Entities.Configurations;
using AwareTest.ModelNew.Model;
using Microsoft.EntityFrameworkCore;

namespace SPWCircularofLux.Data
{
	public class AwareServiceDbContext : DbContext
	{
        public DbSet<EmployeeModel> Employee { get; set; } = null!;
        public DbSet<TerritoriesModel> Territories { get; set; } = null!;
        public DbSet<RegionModel> Region { get; set; } = null!;
        public DbSet<EmployeeTerritoriesModel> EmployeeTerritories { get; set; } = null!;

        public AwareServiceDbContext(DbContextOptions<AwareServiceDbContext> options) : base(options)
        {
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new EmployeeConfig());

            builder
                .ApplyConfiguration(new TerritoriesConfig());

            builder
                .ApplyConfiguration(new RegionConfig());

            builder
                .ApplyConfiguration(new EmployeeTerritoriesConfig());
        }


    }
}

