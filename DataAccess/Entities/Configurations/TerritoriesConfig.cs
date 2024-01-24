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
    public class TerritoriesConfig : IEntityTypeConfiguration<TerritoriesModel>
    {

        public void Configure(EntityTypeBuilder<TerritoriesModel> builder)
        {
            builder
                .HasKey(m => m.TerritoryID);

            builder
                .Property(m => m.TerritoryID)
            .UseIdentityColumn();

            builder
            .HasOne(t => t.Region)
            .WithMany(r => r.Territories)
            .HasForeignKey(t => t.RegionID);

            builder
               .ToTable("Territories", "ToTable");
        }
    }
}
