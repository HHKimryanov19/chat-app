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
    public class ChatConfiguration: IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder
                .HasOne(c => c.FirstUser)
                .WithMany(u => u.Sent)
                .HasForeignKey(c => c.FirstUserId);


            builder
                .HasOne(c => c.SecondUser)
                .WithMany(u => u.Recieved)
                .HasForeignKey(c => c.SecondUserId);

            builder
                .Property(c => c.LastMessageDate)
                .IsRequired();

            builder
                .Property(c => c.Image)
                .IsRequired(false);
        }
    }
}
