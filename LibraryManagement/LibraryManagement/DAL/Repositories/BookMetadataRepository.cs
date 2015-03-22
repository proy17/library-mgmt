using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.TestData;
    public class BookMetadataRepository : MetadataRepository<BookMetadataEntity>

    {
        public override BookMetadataEntity SelectByName(string name)
        {
            var bookMetadataList = TestData.metadataEntities.Cast<BookMetadataEntity>().ToList();
            return bookMetadataList.Find(metadata => metadata.BookName == name);
        }
    }
}


