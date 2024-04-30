﻿using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnQuestAPI.Data.Map
{
    public class DisciplinaMap : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).IsRequired().HasMaxLength(255);
            builder.HasMany(d => d.Perguntas).WithOne().HasForeignKey(d => d.DisciplinaId);
            builder.Property(d => d.Nota).HasColumnType("decimal(5, 2)").HasDefaultValue(0.0);

        }
    }
}