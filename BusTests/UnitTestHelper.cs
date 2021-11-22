using System;
using AutoMapper;
using BusStop.Data;
using BusStop.Data.BusStop;
using Microsoft.EntityFrameworkCore;

namespace BusTests
{
    public class UnitTestHelper
    {
        public static DbContextOptions<BusStop.Data.BusStopContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<BusStop.Data.BusStopContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new BusStop.Data.BusStopContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(BusStopContext context)
        {
            context.BusStations.Add(new BusStop.Data.BusStop.BusDto { Id = 1, CountOfBuses = 213211, Location = "dqwqwqd" });
            context.Clients.Add(new BusStop.Data.Client.ClientDto { Id = 1, Name = "ddqwq", SecondName = "dqwqwqd", CountOfTravels = 332412});
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new DaoBusStationProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}