using CommandService.Models;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Repository
{
    /// <summary>
    /// Invoked in middleware startup file to populate db
    /// </summary>
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IGrpcPlatformDataClient>();
                var platforms = grpcClient.PullAllPlatorms();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(), platforms);
            }
        }

        /// <summary>
        /// Pull data from Platform Service via grpc and save data to Command db
        /// </summary>
        /// <param name="commandRepo">Command repo service</param>
        /// <param name="platforms">platforms from grpc</param>
        private static void SeedData(ICommandRepo commandRepo, IEnumerable<Platform> platforms)
        {
            if(platforms == null)
            {
                Console.WriteLine("Cannot seed platforms. No Platforms available");
                return;
            }
            Console.WriteLine("Seeding new platforms...");
            foreach (var platform in platforms)
            {
                if (!commandRepo.ExternalPlaformExits(platform.ExternalID))
                {
                    commandRepo.CreatePlatform(platform);
                    commandRepo.SaveChanges();
                }
            }
        }
    }
}
