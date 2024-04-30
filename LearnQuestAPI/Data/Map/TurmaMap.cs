﻿using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace LearnQuestAPI.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).HasMaxLength(100).IsRequired();
            builder.HasMany(t => t.Disciplinas).WithOne().HasForeignKey(t => t.TurmaId);
        }
    }
}
