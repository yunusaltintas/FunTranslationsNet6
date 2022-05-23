using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunTranslation.Domain.Seeds
{
    public class UserSeedData : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "yunus",
                    NormalizedUserName = "YUNUS",
                    Email = "yunus@yunus.com",
                    NormalizedEmail = "YUNUS@YUNUS.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEDJ+SO90wp7h8BBv3JhnGZmuy/ai+JUhV0dgm20MbALPe+nP9jA8+NlzsnNXqjeA6g==",
                    SecurityStamp = "5NBSKH6Z6VKWRPWHFEXTEPBJC7IULAKT",
                    ConcurrencyStamp = "4d040826-902d-4a0c-8502-1d3a1d3da80a",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEDJ+SO90wp7h8BBv3JhnGZmuy/ai+JUhV0dgm20MbALPe+nP9jA8+NlzsnNXqjeA6g==",
                    SecurityStamp = "VS4SLSW5QYXLWLRGP4X2J3G5NVJLUICB",
                    ConcurrencyStamp = "3f7a99c7-1446-49c1-aa7e-6860a5165569",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );
        }
    }
}
