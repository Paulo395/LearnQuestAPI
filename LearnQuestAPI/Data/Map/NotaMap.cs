using LearnQuestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnQuestAPI.Data.Map
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Pontuacao).IsRequired();
            builder.Property(x => x.Data).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}
