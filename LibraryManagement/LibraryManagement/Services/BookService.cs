using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.EntityModelTranslator;

namespace LibraryManagement.Services
{
    using LibraryManagement.DAL;
    using LibraryManagement.DAL.Repositories;
    using LibraryManagement.Models;
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.Enums;

    /// <summary>
    /// The book metadata service.
    /// </summary>
    public class BookService : IBookService
    {
        public BookService(ItemRepository<BookEntity> bookRepository, 
            MetadataRepository<BookMetadataEntity> bookMetadataRepository,
            ITransalator<BookEntity,BookModel> bookTransalator,     
           ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator)
        {
            this.bookRepository = bookRepository;
            this.bookTransalator = bookTransalator;
            this.bookMetadataRepository = bookMetadataRepository;
            this.bookMetadataTransalator = bookMetadataTransalator;
        }


        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private ItemRepository<BookEntity> bookRepository;
        /// <summary>
        /// 
        /// </summary>
        private MetadataRepository<BookMetadataEntity> bookMetadataRepository = null;


        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<BookEntity, BookModel> bookTransalator=null;
        private ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator =null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BookModel SelectByBookID(string bookId)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectByID(bookId);
            var bookMetadataEntity = (BookMetadataEntity)this.bookMetadataRepository.SelectByID(bookEntity.BookMetaData);
            var bookModel = this.bookTransalator.TransalateToModel(bookEntity);
            bookModel.BookMetaDataModel = this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);
            return bookModel;
        }

        public BookModel SelectByIDandByStatus(string id, ItemStatus itemstatus)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectByID(id);
            return this.bookTransalator.TransalateToModel(bookEntity);
        }
        /// <summary>
        /// Check if book metadata available
        /// </summary>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        public bool isAvailable(string metadataId)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectItemByMetadataId(metadataId, ItemStatus.Available);
            return bookEntity != null;
        }

        public BookModel SelectBookByMetadataId(string metadataId, ItemStatus itemStatus)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectItemByMetadataId(metadataId, itemStatus);
            var bookMetadataEntity = (BookMetadataEntity)this.bookMetadataRepository.SelectByID(bookEntity.BookMetaData);
            var bookMetadataModel = this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);
            var bookModel = this.bookTransalator.TransalateToModel(bookEntity);
            bookModel.BookMetaDataModel = bookMetadataModel;
            return bookModel;
        }
        /// <summary>
        /// insert book metadata
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public bool Insert(BookModel bookModel)
        {
            try
            {
                var bookEntity = this.bookTransalator.TransalateToEntity(bookModel);                
                this.bookRepository.Insert(bookEntity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// update bookmetadata
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public bool Update(BookModel bookModel)
        {
            try
            {
                var bookEntity = this.bookTransalator.TransalateToEntity(bookModel);
                this.bookRepository.Update(bookEntity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}