using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoleBased.Model;
using RoleBased.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Infrastructure.Persistence.Configurations;

public class LoginDBConfiguration : IEntityTypeConfiguration<LoginDB>
{
    public void Configure(EntityTypeBuilder<LoginDB> builder)
    {
        builder.HasKey(e => e.RegNo);

        builder.HasData(new
        {
            RegNo ="C183077",
            Pass="12345",
            Role="student",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            LastModified = DateTimeOffset.Now,
            Status = EntityStatus.Created
        });
    }

}
