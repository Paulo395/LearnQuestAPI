using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnQuestAPI.Data.Map
{
    public class SeminarioMap : IEntityTypeConfiguration<Seminario>
    {
        public void Configure(EntityTypeBuilder<Seminario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LinkVideo).IsRequired().HasMaxLength(300);
        }
    }
}
