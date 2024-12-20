using Dapr.Client;
using RestSharp;
using User.Domain;
using User.Interfaces;

namespace User.Adapters
{
    public class ProductSvcAdapter : IProductSvcAdapter
    {
        DaprClient _client; 
        public ProductSvcAdapter(DaprClient client) 
        { 
            _client = client;
        }

        public async Task<Product[]> GetProducts(
        int maxItems = 10, CancellationToken cancellationToken = default)
        {
            try
            {
                List<Product>? products =
                await _client.InvokeMethodAsync<List<Product>>(
                    HttpMethod.Get,
                    "productapi",
                    "products",
                    cancellationToken);

                return products?.Take(maxItems)?.ToArray() ?? [];
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
