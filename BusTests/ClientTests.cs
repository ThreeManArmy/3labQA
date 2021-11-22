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
    public class ClientTests
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "/api/Client/BusStops/clients/";

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
            var client = JsonConvert.DeserializeObject<BusStop.Orchestrators.Client.Client>(stringResponse);

            Assert.AreEqual(1, client.Id);
            Assert.AreEqual("ddqwq", client.Name);
            Assert.AreEqual("dqwqwqd", client.SecondName);
            Assert.AreEqual(332412, client.CountOfTravels);
        }
        [Test]
        public async Task clientsController_Add_AddsclientToDatabase()
        {
            var client = new BusStop.Orchestrators.Client.Client() { Name = "ddqqfewfwwq", SecondName = "fqwewefqw", CountOfTravels = 124242 };
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync($"/api/Client/BusStops/{1}/clients", content);


            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var clientInResponse = JsonConvert.DeserializeObject<BusStop.Orchestrators.Client.Client>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();
                var databaseclient = await context.Clients.FindAsync(clientInResponse.Id);
                Assert.AreEqual(databaseclient.Id, clientInResponse.Id);
                Assert.AreEqual(databaseclient.Name, clientInResponse.Name);
                Assert.AreEqual(databaseclient.SecondName, clientInResponse.SecondName);
                Assert.AreEqual(databaseclient.CountOfTravels, clientInResponse.CountOfTravels);
            }
        }
        [Test]
        public async Task clientsController_Update_UpdatesclientInDatabase()
        {
            var client = new BusStop.Orchestrators.Client.Client { Id = 1, CountOfTravels = 1843 };
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(client), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PatchAsync($"/api/client/{client.Id}", content);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();
                var databaseclient = await context.Clients.FindAsync(client.Id);
                Assert.AreEqual(client.CountOfTravels, databaseclient.CountOfTravels);
            }
        }
        [Test]
        public async Task BusController_DeleteById_DeletesBookFromDatabase()
        {
            var clientId = 1;
            var httpResponse = await _client.DeleteAsync("api/Client/" + clientId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<BusStopContext>();

                Assert.AreEqual(0, context.Clients.Count());
            }
        }
    }
}
