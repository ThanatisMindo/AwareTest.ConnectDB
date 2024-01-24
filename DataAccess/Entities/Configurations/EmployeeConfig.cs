using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AwareTest.ModelNew.Model;

namespace AwareTest.DataAccess.Entities.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<EmployeeModel>
    {

        public void Configure(EntityTypeBuilder<EmployeeModel> builder)
        {
            builder
                .HasKey(m => m.EmployeeId);

            builder
                .Property(m => m.EmployeeId)
                .UseIdentityColumn();

            builder
               .ToTable("Employees", "dbo");
        }
    }
}
