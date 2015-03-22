using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.EntityModelTranslator
{
    /// <summary>
    /// The book transalator.
    /// </summary>
    public class BookTransalator : ITransalator<BookEntity, BookModel>
    {
        private ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookTransalator"/> class.
        /// </summary>
        public BookTransalator()
        {
        }

        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="bookEntity">
        /// The book entity.
        /// </param>
        /// <returns>
        /// The <see cref="BookModel"/>.
        /// </returns>
        public BookModel TransalateToModel(BookEntity bookEntity)
        {
            var bookModel = new BookModel
            {
                ID = bookEntity.ID,
                BookStatus = bookEntity.Status
            };
            return bookModel;
        }

        public BookModel TranslateToModel(BookEntity bookEntity, BookMetadataEntity bookMetadata)
        {
            var bookModel = TransalateToModel(bookEntity);
            bookModel.BookMetaDataModel = this.bookMetadataTransalator.TransalateToModel(bookMetadata);
            return bookModel;
        }

        /// <summary>
        /// The transalate to entity.
        /// </summary>
        /// <param name="bookModel">
        /// The book model.
        /// </param>
        /// <returns>
        /// The <see cref="BookEntity"/>.
        /// </returns>
        public BookEntity TransalateToEntity(BookModel bookModel)
        {
            var bookEntity = new BookEntity
            {
                BookMetaData = bookModel.BookMetaDataModel.ID,
                ID = bookModel.ID,
                Status = bookModel.BookStatus
            };
            return bookEntity;
        }

        /// <summary>
        /// The transalate to entities.
        /// </summary>
        /// <param name="bookMetadataModels">
        /// The book metadata models.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<BookEntity> TransalateToEntities(List<BookModel> bookModels)
        {
            var bookEntities = (from model in bookModels
                                select TransalateToEntity(model)).ToList();
            return bookEntities;
        }

        /// <summary>
        /// The transalate to models.
        /// </summary>
        /// <param name="bookMetadataEntity">
        /// The book metadata entity.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<BookModel> TransalateToModels(List<BookEntity> bookMetadataEntity)
        {
            var bookModels = (from entity in bookMetadataEntity
                              select TransalateToModel(entity)).ToList();
            return bookModels;
        }
    }
}