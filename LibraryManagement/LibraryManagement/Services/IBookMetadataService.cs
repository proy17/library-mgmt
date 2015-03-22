using System.Collections.Generic;

namespace LibraryManagement.Services
{
    using LibraryManagement.Models;

    /// <summary>
    /// The book metadata service.
    /// </summary>
    public interface IBookMetadataService : IService
    {
        List<BookMetadataModel> GetAllBookMetadatas();
        BookMetadataModel Insert(BookMetadataModel bookmetadataModel);
        BookMetadataModel GetAllBookMetadatasByName(string name);
        BookMetadataModel GetBookMetadatasByID(string id);
    }
}
