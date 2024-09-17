using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestRoomMVC.Models;
using System.Collections.Generic;

namespace QuestRoomMVC.Data
{
    public class QRContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<QuestRoom> QuestRooms { get; set; }

        public QRContext(DbContextOptions<QRContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<QuestRoom>().HasData(
                new QuestRoom
                {
                    Id = 1,
                    Name = "Haunted Mansion",
                    Description = "A scary haunted mansion filled with ghosts and mysteries.",
                    Duration = 60,
                    MinPlayers = 2,
                    MaxPlayers = 6,
                    MinAge = 16,
                    Address = "123 Spooky St.",
                    Phone = "+123456789",
                    Email = "contact@hauntedmansion.com",
                    Company = "Ghostly Adventures Inc.",
                    Rating = 5,
                    FearLevel = 5,
                    DifficultyLevel = 4,
                    Logo = "haunted_logo.png"
                },
                new QuestRoom
                {
                    Id = 2,
                    Name = "Pirate's Cove",
                    Description = "An adventurous escape room in a pirate's cove.",
                    Duration = 90,
                    MinPlayers = 3,
                    MaxPlayers = 8,
                    MinAge = 12,
                    Address = "456 Ocean Ave.",
                    Phone = "+987654321",
                    Email = "info@piratescove.com",
                    Company = "Adventure Rooms Ltd.",
                    Rating = 4,
                    FearLevel = 2,
                    DifficultyLevel = 3,
                    Logo = "pirate_logo.png"
                }
            );
        }
    }
}
