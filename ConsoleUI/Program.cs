using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console UI
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            Console.WriteLine("**   Bütün  Liste   **");
            productManager.GetAll().ForEach(x=>Console.WriteLine("{0} - {1}",x.ProductId,x.ProductName,x.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");
            
            Console.WriteLine("**   KategoriId Göre  **");
            productManager.GetAllByCategoryId(1).ForEach(p => Console.WriteLine("{0} - {1} - {2}", p.ProductId, p.ProductName,p.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");

            Console.WriteLine("**   Fiyata Göre  **");
            productManager.GetByUnitPrice(10,15).ForEach(p=> Console.WriteLine("{0} - {1} - {2}", p.ProductId, p.ProductName, p.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");

        }
    }
}
