//using ECommerceApplication.Models;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        void ProductAdd(Product product);
        Product GetByID(int id);
        void ProductDelete(Product product);
        void ProductUpdate(Product product);
        List<Product> GetListByProductID(int id);
        List<Product> GetListByCategoryID(int id);
        List<Product> GetListBySList(int id);

    }
}
