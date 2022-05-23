using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslation.Domain.Seeds
{
    public class LanguageSeedData : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                new Language
                {
                    Id = 1,
                    LanguageName = "Leetspeak",
                    CreateUserId = 1,
                    CreateDate = DateTime.Now

                },
               new Language
               {
                   Id = 2,
                   LanguageName = "Morse",
                   CreateUserId = 1,
                   CreateDate = DateTime.Now

               },
               new Language
               {
                   Id = 3,
                   LanguageName = "Hodor",
                   CreateUserId = 1,
                   CreateDate = DateTime.Now

               },
               new Language
               {
                   Id = 4,
                   LanguageName = "Chef",
                   CreateUserId = 1,
                   CreateDate = DateTime.Now

               },
               new Language
               {
                   Id = 5,
                   LanguageName = "Shakespeare",
                   CreateUserId = 1,
                   CreateDate = DateTime.Now

               }
            );
        }
    }
}

