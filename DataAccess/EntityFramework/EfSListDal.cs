using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfSListDal : GenericRepository<SList>, ISListDal
    {
    }
}
