using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    public interface IRepository<BaseEntity> 
        //where TEntity : BaseEntity
    {
        IEnumerable<BaseEntity> SelectAll();
        BaseEntity SelectByID(string id);
        void Insert(BaseEntity obj);
        void Update(BaseEntity obj);
        void Delete(BaseEntity obj);
    }

}
