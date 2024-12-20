using Dapr.Client;
using RestSharp;
using User.Domain;
using User.Interfaces;

namespace User.Adapters
{
    public class ProductSvcAdapter : ISvcAdapter
    {
        DaprClient _client; 
        public ProductSvcAdapter(DaprClient client) 
        { 
            _client = client;
        }

        public async Task<Product[]> GetProducts(
        int maxItems = 10, CancellationToken cancellationToken = default)
        {
            List<Product>? products =
                await _client.InvokeMethodAsync<List<Product>>(
                    HttpMethod.Get,
                    "apiservice",
                    "product",
                    cancellationToken);

            return products?.Take(maxItems)?.ToArray() ?? [];
        }

    }
}
