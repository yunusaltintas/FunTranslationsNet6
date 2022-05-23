using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslation.Domain.EntityTypeBuilder
{
    public class PastTranslationTypeBuilder : IEntityTypeConfiguration<PastTranslation>
    {
        public void Configure(EntityTypeBuilder<PastTranslation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
            builder.Property(p => p.OriginalText)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(1050);
            builder.Property(p => p.TranslatedText)
               .IsRequired()
               .HasColumnType("nvarchar")
               .HasMaxLength(1050);
        }
    }
}
