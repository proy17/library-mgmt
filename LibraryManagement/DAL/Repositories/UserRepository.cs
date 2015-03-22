using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.TestData;
   
    public class UserRepository<TEntity> : IRepository<UserEntity>
        where TEntity : UserEntity
    {
        public IEnumerable<UserEntity> SelectAll() { return null; }
        public UserEntity SelectByID(string id) { return TestData.userEntities.Find(role => role.ID == id); }
        public void Insert(UserEntity obj)
        {
            TestData.userEntities.Add(obj);
        }
        public void Update(UserEntity obj)
        {
            TestData.userEntities.Remove(obj);
            TestData.userEntities.Add(obj);
        }
        public void Delete(UserEntity obj)
        {
            TestData.userEntities.Remove(obj);
        }
    }


}