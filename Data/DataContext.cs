using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    //Comunmente se herada solo el DbContext pero en nuestro caso vamos agregar la Interfaz para el control de SaveChangesAsync (Usando Task)
    public class DataContext:DbContext, IDataContext
    {
        //Esto semantiene siempre en nuestro DataContext
        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
            
        }
        //Siempre listamos los DbSet de nuestros Models.
        public DbSet<Product> Products {get; set; }
    }
}