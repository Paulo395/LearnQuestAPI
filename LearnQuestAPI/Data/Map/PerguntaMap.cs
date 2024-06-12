using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LearnQuestAPI.Data.Map
{
    public class PerguntaMap : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);

            builder.HasMany(p => p.Respostas)
                .WithOne()
                .HasForeignKey(r => r.PerguntaId)
                .IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
