using AwareTest.ModelNew.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwareTest.ModelNew.Model;

namespace AwareTest.DataAccess.Entities.Configurations
{
    public class RegionConfig : IEntityTypeConfiguration<RegionModel>
    {

        public void Configure(EntityTypeBuilder<RegionModel> builder)
        {
            builder
                .HasKey(m => m.RegionID);

            builder
                .Property(m => m.RegionID)
                .UseIdentityColumn();

            builder
               .ToTable("Region", "ToTable");
        }
    }
}
