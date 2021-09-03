using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        //Referencia a nuestra inferfaz del data Context (El cual hace referencia a que debemos tener un DbSet de Products)
        private readonly IDataContext _context;
        //Siempre creamos este constructor donde hacermos referencia a nuestro Idatacontext con el DataContext Global.
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }
        //Los metodos implementados seran Tasks para facilitar la concurrencia y tambien seran asyncronos (para eso necesitamos agregar el await en lo que devolvamos)
        public async Task Add(Product product)
        {
            //Estos metodod ya son lo que vienen con Entity Framework
            _context.Products.Add(product);
            //Recordamos el evento de la Intefaz de nuestro data Context
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Products.FindAsync(id);
            if(itemToDelete==null)
                throw new NullReferenceException();
            
            _context.Products.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
             var itemToUpdate = await _context.Products.FindAsync(product.ProductId);
            if(itemToUpdate==null)
                throw new NullReferenceException();
            
            itemToUpdate.Name= product.Name;
            itemToUpdate.Price = product.Price;
            await _context.SaveChangesAsync();
        }
    }
}