using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnQuestAPI.Data.Map
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Conteudo).IsRequired().HasMaxLength(500);
        }
    }
}
