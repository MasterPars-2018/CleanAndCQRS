using CleanAndCQRS.Domain.Domains.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAndCQRS.Infrastructure.Configurations
{
    internal class ToDoListEntityTypeConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.OwnsMany(x => x.Tasks);
        }
    }
}
