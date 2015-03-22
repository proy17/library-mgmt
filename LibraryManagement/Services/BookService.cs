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
    public class BookService : IService
    {
        public BookService(
            // BookRepository bookRepository, BookTransalator bookTransalator
            )
        {
            //this.bookRepository = bookRepository;
            //this.bookTransalator = bookTransalator;
            this.bookRepository = new BookRepository<BookEntity>();
            this.bookTransalator = new BookTransalator();
        }

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private ItemRepository<BookEntity> bookRepository = null;

        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<BookEntity, BookModel> bookTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BookModel SelectByID(string id)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectByID(id);
            return this.bookTransalator.TransalateToModel(bookEntity);
        }

        public BookModel SelectByIDandByStatus(string id, ItemStatus itemstatus)
        {
            var bookEntity = (BookEntity)this.bookRepository.SelectByID(id);
            return this.bookTransalator.TransalateToModel(bookEntity);
        }
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
        

    }
}