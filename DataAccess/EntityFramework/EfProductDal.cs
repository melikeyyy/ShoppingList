using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
//using ECommerceApplication.Models;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
    }
}
