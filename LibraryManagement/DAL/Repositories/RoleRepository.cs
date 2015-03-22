
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.TestData;
    public class RoleRepository : IRepository<RoleEntity>
    {
       public IEnumerable<RoleEntity> SelectAll(){return null;}
       public RoleEntity SelectByID(string id) { return TestData.roleEntities.Find(role => role.ID == id); }
       public void Insert(RoleEntity obj) { }
       public void Update(RoleEntity obj) { }
       public void Delete(RoleEntity obj) { }
    }


}

