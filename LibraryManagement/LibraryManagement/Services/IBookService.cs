
namespace LibraryManagement.Services
{
    using LibraryManagement.Enums;
    using LibraryManagement.Models;

    /// <summary>
    /// The book metadata service.
    /// </summary>
    public interface IBookService : IService
    {
        BookModel SelectByBookID(string id);
        
        BookModel SelectByIDandByStatus(string id, ItemStatus itemstatus);

        bool Insert(BookModel bookModel);

        bool Update(BookModel bookModel);

        bool isAvailable(string metadataId);

        BookModel SelectBookByMetadataId(string metadataId, ItemStatus itemStatus);
    }
}