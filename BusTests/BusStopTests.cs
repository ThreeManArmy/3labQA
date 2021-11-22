using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BusStop.Data;
using BusTests;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BusTests
{
    public class BusStopTests
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "api/Bus/";

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        [Test]
        public async Task clientsController_GetById_ReturnsclientModel()
        {
            var httpResponse = await _client.GetAsync(RequestUrl + 1);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var bus = JsonConvert.DeserializeObject<BusStop.Orchestrators.BusStop.Bus>(stringResponse);

            Assert.AreEqual(1, bus.Id);
            Assert.AreEqual(332412, bus.CountOfBuses);
            Assert.AreEqual("dqwqwqd", bus.Location);
        }
        [Test]
        public async Task clientsController_Add_AddsclientToDatabase()
        {
            var bus = new BusStop.Orchestrators.BusStop.Bus() { CountOfBuses = 124232, Location = "sawfas"};
            var content = new StringContent(JsonConvert.SerializeObject(bus), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync($"/api/Bus/{bus.Id}", content);


            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var busInResponse = JsonConvert.DeserializeObject<BusStop.Orchestrators.BusStop.Bus>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();
                var databaseclient = await context.BusStations.FindAsync(busInResponse.Id);
                Assert.AreEqual(databaseclient.Id, busInResponse.Id);
                Assert.AreEqual(databaseclient.Location, busInResponse.Location);
                Assert.AreEqual(databaseclient.CountOfBuses, busInResponse.CountOfBuses);
            }
        }
        [Test]
        public async Task clientsController_Update_UpdatesBusInDatabase()
        {
            var bus = new BusStop.Orchestrators.BusStop.Bus { Id = 1, CountOfBuses = 0 };
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(bus), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PatchAsync($"/api/Bus/{bus.Id}", content);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();
                var databaseclient = await context.BusStations.FindAsync(bus.Id);
                Assert.AreEqual(bus.CountOfBuses, databaseclient.CountOfBuses);
            }
        }
        [Test]
        public async Task BusController_DeleteById_DeletesBookFromDatabase()
        {
            var clientId = 1;
            var httpResponse = await _client.DeleteAsync("api/Bus/" + clientId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();

                Assert.AreEqual(0, context.BusStations.Count());
            }
        }
    }
}
