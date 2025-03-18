using CA.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Data.Configurations
{
    public class ImageConfiguration: IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .Property(i => i.Picture)
                .IsRequired();

            builder
                .HasOne(i => i.SendBy)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.UserId);

            builder
                .Property(i => i.SendOn)
                .IsRequired();
        }
    }
}
