using FunTranslation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslation.Domain.EntityTypeBuilder
{
    public class CommonEntityTypeBuilder : IEntityTypeConfiguration<CommonEntity>
    {
        public void Configure(EntityTypeBuilder<CommonEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);
        }
    }
}
