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
    public class LendingTransalator : ITransalator<LendingEntity, LendingModel>
    {
        private ITransalator<BookMetadataEntity, BookMetadataModel> bookMetadataTransalator = null;

        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="lendingEntity">
        /// The book entity.
        /// </param>
        /// <returns>
        /// The <see cref="BookModel"/>.
        /// </returns>
        public LendingModel TransalateToModel(LendingEntity lendingEntity)
        {
            var lendingModel = new LendingModel
            {
                ID = lendingEntity.ID,
                ItemIssued = lendingEntity.ItemIssued,
                Issuer = lendingEntity.Issuer,
                Issuedate = lendingEntity.IssueDate


            };
            return lendingModel;
        }

        public LendingEntity TransalateToEntity(LendingModel lendingModel)
        {
            var lendingEntity = new LendingEntity
                                    {
                                        ID = lendingModel.ID,
                                        IssueDate = lendingModel.Issuedate,
                                        Issuer = lendingModel.Issuer,
                                        ItemIssued = lendingModel.ItemIssued
                                    };
            return lendingEntity;
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
        public List<LendingEntity> TransalateToEntities(List<LendingModel> lendingModels)
        {
            var lendingEntities = (from model in lendingModels
                                   select this.TransalateToEntity(model)).ToList();
            return lendingEntities;
        }

        /// <summary>
        /// The transalate to models.
        /// </summary>
        /// <param name="lendingEntity">
        /// The book metadata entity.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<LendingModel> TransalateToModels(List<LendingEntity> lendingEntity)
        {
            var lendingModels = (from entity in lendingEntity
                                 select TransalateToModel(entity)).ToList();
            return lendingModels;
        }
    }
}