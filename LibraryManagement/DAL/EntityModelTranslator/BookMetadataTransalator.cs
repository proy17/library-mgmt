using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.EntityModelTranslator
{


    public class BookMetadataTransalator : ITransalator<BookMetadataEntity, BookMetadataModel>
    {
        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="bookMetadataEntity">
        /// The book metadata entity.
        /// </param>
        /// <returns>
        /// The <see cref="BookMetadataModel"/>.
        /// </returns>
        public BookMetadataModel TransalateToModel(BookMetadataEntity bookMetadataEntity)
        {

            var MetaData = new BookMetadataModel
               {
                   ID = bookMetadataEntity.ID,
                   Author = bookMetadataEntity.Author,                   
                   BookName = bookMetadataEntity.BookName
               };
            return MetaData;

        }

        /// <summary>
        /// The transalate to entity.
        /// </summary>
        /// <param name="bookMetadataModel">
        /// The book metadata model.
        /// </param>
        /// <returns>
        /// The <see cref="BookMetadataEntity"/>.
        /// </returns>
        public BookMetadataEntity TransalateToEntity(BookMetadataModel bookMetadataModel)
        {
            var bookMetaData = new BookMetadataEntity
                {
                    ID = bookMetadataModel.ID,
                    Author = bookMetadataModel.Author,
                    BookName = bookMetadataModel.BookName
                };

            return bookMetaData;
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
        public List<BookMetadataEntity> TransalateToEntities(List<BookMetadataModel> bookMetadataModels)
        {
            var bookMetadataEnties = (from model in bookMetadataModels
                                      select TransalateToEntity(model)).ToList();

            return bookMetadataEnties;
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
        public List<BookMetadataModel> TransalateToModels(List<BookMetadataEntity> bookMetadataEntity)
        {
            var bookMetadataModels = (from entity in bookMetadataEntity
                                      select TransalateToModel(entity)).ToList();

            return bookMetadataModels;
        }
    }
}