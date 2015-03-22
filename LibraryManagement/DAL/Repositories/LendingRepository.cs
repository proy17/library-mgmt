using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.Enums;
    using LibraryManagement.TestData;

    public class LendingRepository<TEntity> : IRepository<LendingEntity>
        where TEntity : LendingEntity
    {
        private ItemRepository<BookEntity> itemRepository = null;

        public IEnumerable<LendingEntity> SelectAll() { return null; }
       
        public LendingEntity SelectByID(string id)
        { 
            return TestData.lendingEntities.Find(lendingItem=>lendingItem.ID==id);
        }

        public void Insert(LendingEntity obj)
        {
            TestData.lendingEntities.Add(obj);
        }

        public void Update(LendingEntity obj)
        {
            TestData.lendingEntities.Remove(obj);
            TestData.lendingEntities.Add(obj);
        }

        public void Delete(LendingEntity obj)
        {
            TestData.lendingEntities.Remove(obj);
        }

        public LendingRepository()
        {
            itemRepository = new BookRepository<BookEntity>();
        }

        public  List<LendingEntity> SelectAllOverdueLendingInformation()
        {
           var overDueItems= itemRepository.SelectAllByStatus(ItemStatus.Borrowed).ToList();
            var lendItemsList = TestData.itemEntities.Cast<LendingEntity>().ToList();
            var overDueLendingitems = (from lendingItem in lendItemsList
                         from bookItem in overDueItems
                         where lendingItem.Issuer == bookItem.ID && lendingItem.IssueDate <= DateTime.Today.AddDays(-7)
                         select lendingItem).ToList();

            return overDueLendingitems;
        }
       
    }

}
