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
            ForProduct();
            ForCategory();

            //DTO => Data Transformation Object

        }

        private static void ForCategory()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            Console.WriteLine("**   Kategori bütün  Liste   **");
            categoryManager.GetAll().ForEach(p => Console.WriteLine("{0} - {1}", p.CategoryId, p.CategoryName));
            Console.WriteLine("-------------------------------------------------------\n");


            Console.WriteLine("**   Kategori 1 Nolu  Liste   **");
            Console.WriteLine("{0} - {1}", categoryManager.GetById(1).CategoryId, categoryManager.GetById(1).CategoryName);
            Console.WriteLine("-------------------------------------------------------\n");


            Console.WriteLine("**   Kategori 2 Nolu  Liste   **");
            Console.WriteLine("{0} - {1}", categoryManager.GetById(2).CategoryId, categoryManager.GetById(2).CategoryName);
            Console.WriteLine("-------------------------------------------------------\n");
        }

        private static void ForProduct()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            Console.WriteLine("**   Bütün  Liste   **");
            productManager.GetAll().ForEach(x => Console.WriteLine("{0} - {1}", x.ProductId, x.ProductName, x.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");

            Console.WriteLine("**   KategoriId Göre  **");
            productManager.GetAllByCategoryId(1)
                .ForEach(p => Console.WriteLine("{0} - {1} - {2}", p.ProductId, p.ProductName, p.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");

            Console.WriteLine("**   Fiyata Göre  **");
            productManager.GetByUnitPrice(10, 15)
                .ForEach(p => Console.WriteLine("{0} - {1} - {2}", p.ProductId, p.ProductName, p.UnitPrice));
            Console.WriteLine("-------------------------------------------------------\n");
            Console.WriteLine("\n\n");

            Console.WriteLine("**   Fiyata Göre  **");
            productManager.GetProductDetails().ForEach(p => Console.WriteLine("{0} / {1} / {2} / {3}", p.ProductId, p.ProductName, p.UnitsInStock, p.CategoryName));
            Console.WriteLine("-------------------------------------------------------\n");
            Console.WriteLine("\n\n");
        }


    }
}
