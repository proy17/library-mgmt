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
    public class SearchService : IService
    {
        public SearchService()
        {

            this.userRepository = new UserRepository<UserEntity>();
            this.lendingRepository = new LendingRepository<LendingEntity>();
        }

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private IRepository<BaseItemEntity> itemRepository = null;
        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private IRepository<UserEntity> userRepository = null;

        private LendingRepository<LendingEntity> lendingRepository = null;

        private ITransalator<BaseItemEntity, BaseItemModel> itemtransalator = null;

        private ITransalator<LendingEntity, LendingModel> lendingtransalator = null;
        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BaseItemModel SelectByID(string id)
        {
            var itemEntity = this.itemRepository.SelectByID(id);
            return this.itemtransalator.TransalateToModel(itemEntity);
        }

        public List<LendingModel> GetAllOverDueItemsInformation()
        {
            var overDueResults = this.lendingRepository.SelectAllOverdueLendingInformation();
            return this.lendingtransalator.TransalateToModels(overDueResults);
           
        }

    }
}