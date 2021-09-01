using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            productManager.GetAll().ForEach(x=>Console.WriteLine("{0} - {1}",x.ProductId,x.ProductName));
            
        }
    }
}
