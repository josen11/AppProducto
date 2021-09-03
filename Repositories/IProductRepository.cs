using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        //Entonces como trabajaremos con metodos asyncronos y que sean concurrentes (Task)
        //La Interfaz obliga a sus clases que lo heredn a que tengan estos metodos implementados
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update (Product product); 
    }
}