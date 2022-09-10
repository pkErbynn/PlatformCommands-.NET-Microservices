﻿using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            // create a limited scope for AppDbContext service instance  for the population during app run
            // static class so can't use contructor DI
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext? dbContext)
        {
            if (!dbContext.Platforms.Any())
            {
                Console.WriteLine("---> Seeding data...");

                dbContext.Platforms.AddRange(
                     new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                 );

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We hava data already");
            }
        }
    }
}
