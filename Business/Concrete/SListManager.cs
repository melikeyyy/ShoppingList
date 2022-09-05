using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SListManager : ISListService
    {
        ISListDal _sListDal;

        public SListManager(ISListDal ıSListDal)
        {
            _sListDal = ıSListDal;
        }
        public SList GetByID(int id)
        {
            return _sListDal.Get(x => x.SListId == id);
        }

        public List<SList> GetList()
        {
            return _sListDal.List();
        }

        public List<SList> GetListByUser(int id)
        {
            return _sListDal.List(x => x.UserId == id);
        }

        public void SListAdd(SList sList)
        {
            _sListDal.Insert(sList);
        }

        public void SListDelete(SList sList)
        {
            _sListDal.Delete(sList);
        }

        public void SListUpdate(SList sList)
        {
            _sListDal.Update(sList);
        }
    }
}
