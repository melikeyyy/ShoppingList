using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void ProductDelete(Product product)
        {
            _productDal.Delete(product);
        }

        public void ProductUpdate(Product product)
        {
            _productDal.Update(product);
        }

        public void ProductAdd(Product product)
        {
            _productDal.Insert(product);
        }

        public Product GetByID(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public List<Product> GetListByProductID(int id)
        {
            return _productDal.List(x => x.Id == id);
        }

        public List<Product> GetListByCategoryID(int id)
        {
            return _productDal.List(x => x.CategoryId == id);

        }

        public List<Product> GetListBySList(int id)
        {
            return _productDal.List(x => x.SListId == id);
        }
    }
}