using User.Domain;

namespace User.Interfaces
{
    public interface ISvcAdapter
    {

         Task<Product[]> GetProducts(int maxItems = 10, CancellationToken cancellationToken = default);
    }
}
