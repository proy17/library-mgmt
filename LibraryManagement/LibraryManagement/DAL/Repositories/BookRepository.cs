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

    public class BookRepository : ItemRepository<BookEntity>
        
    {
        public override BookEntity SelectByIDandByStatus(string itemId, ItemStatus itemStatus)
        {
            var bookList = TestData.itemEntities.Cast<BookEntity>().ToList();
            return bookList.Find(book => book.ID == itemId && book.Status == itemStatus);
        }

        public override List<BookEntity> SelectAllByStatus(ItemStatus itemStatus)
        {
            var bookList = TestData.itemEntities.Cast<BookEntity>().ToList();
            return bookList.FindAll(book => book.Status == itemStatus);
        }

        public override BookEntity SelectItemByMetadataId(string metadataId, ItemStatus itemStatus)
        {
            var bookList = TestData.itemEntities.Cast<BookEntity>().ToList();
            return bookList.Find(book => book.BookMetaData == metadataId && book.Status == itemStatus);
        }
       
    }

}
