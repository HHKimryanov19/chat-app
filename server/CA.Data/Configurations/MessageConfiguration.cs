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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasOne(m => m.SendBy)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserId);

            builder
                .Property(m => m.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(m => m.SendOn)
                .IsRequired();

            builder
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);
        }
    }
}
