using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DTOs;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kondları
            //Yetkisi var mı ? 
            return new DataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler Listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), true, "Ürün Listelendi");

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), true, "Ürün Listelendi");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), true, "Ürün Listelendi");
        }

        public IResult Add(Product product)
        {
            //Business codes..
            _productDal.Add(product);
            return new Result(true, "Ürün Eklendi");
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == productId),true,"Ürün Listelendi");
        }
    }
}
