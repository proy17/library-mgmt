using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    public interface IRepository<BaseEntity>
    {
        IEnumerable<BaseEntity> SelectAll();
        BaseEntity SelectByID(string id);
        BaseEntity Insert(BaseEntity obj);
        void Update(BaseEntity obj);
        void Delete(BaseEntity obj);
    }

}
