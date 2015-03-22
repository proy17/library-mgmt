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
    public class BookMetadataService :IBookMetadataService
    {
        public BookMetadataService(
             MetadataRepository<BookMetadataEntity> bookMetadataRepository, ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator
            )
        {
            this.bookMetadataRepository = bookMetadataRepository;
            this.bookMetadataTransalator = bookMetadataTransalator;
         
        }

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private MetadataRepository<BookMetadataEntity> bookMetadataRepository = null;

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
        public BookMetadataModel Insert(BookMetadataModel bookmetadataModel)
        {
            try
            {
                var bookMetadataEntity = this.bookMetadataTransalator.TransalateToEntity(bookmetadataModel);
                bookMetadataEntity = (BookMetadataEntity)this.bookMetadataRepository.Insert(bookMetadataEntity);
                return this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BookMetadataModel GetAllBookMetadatasByName(string name)
        {           
            var bookMetadataEntity = this.bookMetadataRepository.SelectByName(name);
            if (bookMetadataEntity != null)
            {
                return this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);
            }
            return null;
        }

        public BookMetadataModel GetBookMetadatasByID(string id)
        {
            var bookMetadataEntity = (BookMetadataEntity)this.bookMetadataRepository.SelectByID(id);
            if (bookMetadataEntity!=null)
            {
                return this.bookMetadataTransalator.TransalateToModel(bookMetadataEntity);
            }
            return null;
        }
    }
}