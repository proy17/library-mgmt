using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.EntityModelTranslator;

namespace LibraryManagement.Services
{
    using LibraryManagement.DAL;
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.DAL.Repositories;
    using LibraryManagement.Models;

    /// <summary>
    /// The book metadata service.
    /// </summary>
    public class BookMetadataService : IService
    {
        public BookMetadataService(
            // BookMetadataRepository bookMetadataRepository, BookMetadataTransalator bookMetadataTransalator
            )
        {
            //this.bookMetadataRepository = bookMetadataRepository;
            // this.bookMetadataTransalator = bookMetadataTransalator;
            this.bookMetadataRepository = new BookMetadataRepository<BookMetadataEntity>();
            this.bookMetadataTransalator = new BookMetadataTransalator();
        }

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private BookMetadataRepository<BookMetadataEntity> bookMetadataRepository = null;

        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<BookMetadataModel> GetAllBookMetadatas()
        {
           
            var bookMetadataEntities = this.bookMetadataRepository.SelectAll().Cast<BookMetadataEntity>().ToList();
            return this.bookMetadataTransalator.TransalateToModels(bookMetadataEntities.ToList());

        }
        public bool Insert(BookMetadataModel bookmetadataModel)
        {
            try
            {
                var bookEntity = this.bookMetadataTransalator.TransalateToEntity(bookmetadataModel);
                this.bookMetadataRepository.Insert(bookEntity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public BookMetadataModel GetAllBookMetadatasByName(string name)
        {
            var bookMetadataEntity = this.bookMetadataRepository.SelectByName(name);
            return this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);

        }
    }
}