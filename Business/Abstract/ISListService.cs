using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISListService
    {
        List<SList> GetList();
        void SListAdd(SList sList);
        SList GetByID(int id);
        void SListDelete(SList sList);
        void SListUpdate(SList sList);
        List<SList> GetListByUser(int id);

    }
}
