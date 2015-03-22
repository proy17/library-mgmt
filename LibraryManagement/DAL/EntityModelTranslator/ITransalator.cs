using LibraryManagement.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.EntityModelTranslator
{
    using System.Collections.Generic;

    interface ITransalator<TEntity, TModel> where TEntity: BaseEntity where TModel: BaseModel
    {
        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="bookMetadataEntity">
        /// The book metadata entity.
        /// </param>
        /// <returns>
        /// The <see cref="TModel"/>.
        /// </returns>
        TModel TransalateToModel(TEntity Entity);

        /// <summary>
        /// The transalate to entity.
        /// </summary>
        /// <param name="bookMetadataModel">
        /// The book metadata model.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity TransalateToEntity(TModel Model);

        /// <summary>
        /// The transalate to entities.
        /// </summary>
        /// <param name="bookMetadataModels">
        /// The book metadata models.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<TEntity> TransalateToEntities(List<TModel> Models);

        /// <summary>
        /// The transalate to models.
        /// </summary>
        /// <param name="bookMetadataEntities">
        /// The book metadata entities.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<TModel> TransalateToModels(List<TEntity> Entities);
    }
}
