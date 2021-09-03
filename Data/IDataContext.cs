using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public interface IDataContext
    {
        //Siempre creamos las DBSet asociados a Clases (OSesa cada clase sera una fila de mi tabbla)
        //No olvicdemos el Ctrl + . para los Quick Fixwa
        DbSet<Product> Products {get; set;}
        //Utilizo un Task (Treading) el cual nos permitira Guardar los cambios Asincronos, y tambien analizar el Cancellation Token ques parte de programacion con Threading
        Task<int> SaveChangesAsync (CancellationToken cancellationToken=default);

    }
}