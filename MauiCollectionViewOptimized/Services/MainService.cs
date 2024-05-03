using MauiCollectionViewOptimized.Models;
using MauiCollectionViewOptimized.Services.Interfaces;
using Org.Apache.Http.Client;
using System.Collections.Frozen;
using System.Net.Http.Json;

namespace MauiCollectionViewOptimized.Services
{
    internal sealed class MainService(HttpClient client) : IMainService
    {
        public async ValueTask<FrozenSet<Person>> GetPeopleAsync()
        {
            try
            {
                var response = await client.GetFromJsonAsync<IEnumerable<Person>>("https://my.api.mockaroo.com/person.json?key=84e61270");
                return response.ToFrozenSet();
            }
            catch (Exception e)
            {
                return Enumerable.Empty<Person>().ToFrozenSet();
            }
        }
    }
}
