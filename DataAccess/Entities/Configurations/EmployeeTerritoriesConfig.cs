using AwareTest.ModelNew.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace AwareTest.DataAccess.Entities.Configurations
{
    public class EmployeeTerritoriesConfig : IEntityTypeConfiguration<EmployeeTerritoriesModel>
    {

        public void Configure(EntityTypeBuilder<EmployeeTerritoriesModel> builder)
        {
            builder 
            .HasKey(et => new { et.EmployeeID, et.TerritoryID });

            builder
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTerritories)
                .HasForeignKey(et => et.EmployeeID);

            builder
                .HasOne(et => et.Territory)
                .WithMany(t => t.EmployeeTerritories)
                .HasForeignKey(et => et.TerritoryID);

            builder
               .ToTable("EmployeeTerritories", "ToTable");
        }
    }
}
