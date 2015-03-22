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
    public class SearchService : ISearchService
    {
        public SearchService(
            IRepository<LendingEntity> lendingRepository, 
            IRepository<UserEntity> userRepository,
            ITransalator<BaseItemEntity, BaseItemModel> itemtransalator,
            ITransalator<LendingEntity, LendingModel> lendingtransalator
            )
        {

            this.userRepository = userRepository;
            this.lendingRepository = lendingRepository;
            this.itemtransalator = itemtransalator;
            this.lendingtransalator = lendingtransalator;
        }

       

        /// <summary>
        /// The book itemRepository repository.
        /// </summary>
        private IRepository<BaseItemEntity> itemRepository = null;
        /// <summary>
        /// The userRepository repository.
        /// </summary>
        private IRepository<UserEntity> userRepository = null;
        /// <summary>
        /// lendingRepository
        /// </summary>
        private IRepository<LendingEntity> lendingRepository = null;
        /// <summary>
        /// 
        /// </summary>
        private ITransalator<BaseItemEntity, BaseItemModel> itemtransalator = null;
        /// <summary>
        /// lendingtransalator
        /// </summary>
        private ITransalator<LendingEntity, LendingModel> lendingtransalator = null;
        /// <summary>
        /// The get all book by id.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BaseItemModel SelectByID(string id)
        {
            var itemEntity = this.itemRepository.SelectByID(id);
            return this.itemtransalator.TransalateToModel(itemEntity);
        }
    }
}