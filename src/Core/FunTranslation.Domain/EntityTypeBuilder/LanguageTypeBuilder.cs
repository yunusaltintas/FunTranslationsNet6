using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslation.Domain.EntityTypeBuilder
{
    public class LanguageTypeBuilder : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasMany(i => i.PastTranslations).WithOne(i => i.Language).HasForeignKey(i => i.LanguageId);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
            builder.Property(p => p.LanguageName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(150);
        }
    }
}
