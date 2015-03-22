using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.TestData;
   
    public class UserRepository : IRepository<UserEntity>
       
    {
        public IEnumerable<UserEntity> SelectAll() { return null; }
        public UserEntity SelectByID(string id) { return TestData.userEntities.Find(user => user.UserEmail == id); }
        public UserEntity Insert(UserEntity obj)
        {
            TestData.userEntities.Add(obj);
            return obj;
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