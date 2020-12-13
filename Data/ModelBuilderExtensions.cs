using TVLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVLibraryAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedPlatformDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = 1,
                    Name = "Netflix"
                },
                new Platform
                {
                    Id = 2,
                    Name = "Prime"
                },
                new Platform
                {
                    Id = 3,
                    Name = "Hotstar"
                },
                new Platform
                {
                    Id = 4,
                    Name = "Zee5"
                },
                new Platform
                {
                    Id = 5,
                    Name = "Voot"
                }
            );
        }

        public static void SeedShowDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>().HasData(
                new Show
                {
                    Id = 1,
                    Title= "The Witcher",
                    Summary= "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.",
                    PlatformId=1,
                    Schedule="Season"
                },
                new Show
                {
                    Id = 2,
                    Title = "Mirzapur",
                    Summary = "Akhandanand Tripathi made millions exporting carpets and became the mafia boss of Mirzapur. His son Munna, an unworthy, power-hungry heir, stops at nothing to continue his father's legacy.",
                    PlatformId = 2,
                    Schedule = "Season"
                },
                new Show
                {
                    Id = 3,
                    Title = "Billions",
                    Summary = "Chuck Rhoades, a sincere but ruthless US attorney, engages in an egoistic battle with hedge fund kingpin Bobby 'Axe' Axelrod as they try to outdo each other in the competitive financial market.",
                    PlatformId = 3,
                    Schedule = "Weekly"
                }
            );
        }
    }
}
