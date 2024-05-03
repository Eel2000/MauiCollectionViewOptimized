using MauiCollectionViewOptimized.Models;
using System.Collections.Frozen;

namespace MauiCollectionViewOptimized.Services.Interfaces
{
    public interface IMainService
    {
        ValueTask<FrozenSet<Person>> GetPeopleAsync();
    }
}
