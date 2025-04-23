using Marten.Schema;

namespace Inventory.API.Data;

public sealed class CatalogInitialData : IInitialData
{
    private readonly Product[] _initialData;

    public CatalogInitialData(Product[] initialData)
    {
        _initialData = initialData;
    }

    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();
        session.Store(_initialData);
        await session.SaveChangesAsync();
    }
}