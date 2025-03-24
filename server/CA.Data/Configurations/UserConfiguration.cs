using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasMany(u => u.Messages)
                .WithOne(m => m.SendBy);

            builder
                .HasMany(u => u.Images)
                .WithOne(i => i.SendBy);

            builder
                .HasMany(u => u.Sent)
                .WithOne(m => m.FirstUser);


            builder
                .HasMany(u => u.Recieved)
                .WithOne(m => m.SecondUser);

            builder
                .Property(u => u.FirstName)
                .IsRequired();


            builder
                .Property(u => u.SecondName)
                .IsRequired();


            builder
                .Property(u => u.Age)
                .IsRequired();
        }
    }
}
