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

    public class LendingRepository : IRepository<LendingEntity>
    {
        private ItemRepository<BookEntity> itemRepository = null;

        public IEnumerable<LendingEntity> SelectAll() { return null; }

        public LendingEntity SelectByID(string id)
        {
            return TestData.lendingEntities.Find(lendingItem => lendingItem.ID == id);
        }

        public LendingEntity Insert(LendingEntity obj)
        {
            obj.ID = Convert.ToString(Utilities.Utilty.GenerateRandomId());
            TestData.lendingEntities.Add(obj);
            return obj;
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
            itemRepository = new BookRepository();
        }

        public List<LendingEntity> SelectAllOverdueLendingInformation(string userId)
        {
            var overDueLendingitems = new List<LendingEntity>();
            var overDueItems = itemRepository.SelectAllByStatus(ItemStatus.Borrowed).ToList();
            var lendItemsList = TestData.lendingEntities.Cast<LendingEntity>().ToList();

            foreach (BookEntity book in overDueItems)
            {
                var lendingitem = (from lendingItem in lendItemsList
                                   where lendingItem.ItemIssued == book.ID && lendingItem.IssueDate <= DateTime.Today.AddDays(-7)
                                   select lendingItem).FirstOrDefault();

                if (lendingitem !=null)
                {
                    overDueLendingitems.Add(lendingitem);
                };
            }

           
            if (!String.IsNullOrEmpty(userId))
            {
                overDueLendingitems = (from lendingItem in overDueLendingitems
                                       where lendingItem.Issuer == userId
                                       select lendingItem).ToList();
            }

            return overDueLendingitems;
        }

        public LendingEntity SelectLendingByItemIdAndUserId(string userId, string itemid)
        {

            var lendItemsList = TestData.lendingEntities.Cast<LendingEntity>().ToList();
            var lendingitem = (from lendingItem in lendItemsList
                               where lendingItem.Issuer == userId && lendingItem.ItemIssued == itemid
                               select lendingItem).FirstOrDefault();

            return lendingitem;
        }
    }

}
