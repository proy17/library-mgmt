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
    public class LendingService : IService
    {
        public LendingService(
            //ItemRepository<BaseItemEntity> itemRepository,
            //   ItemTransalator itemTransalator,
            //UserRepository<UserEntity> userRepository
            )
        {
            // this.itemRepository = itemRepository;
            //this.itemTransalator = itemTransalator;
            // this.itemRepository = new BookRepository();
            //  this.userRepository = new UserRepository<UserEntity>();
        }

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private IRepository<BaseItemEntity> itemRepository = null;
        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private IRepository<UserEntity> userRepository = null;


        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<BaseItemEntity, BaseItemModel> itemTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BaseItemModel SelectByID(string id)
        {
            var itemEntity = this.itemRepository.SelectByID(id);
            return this.itemTransalator.TransalateToModel(itemEntity);
        }

        public bool InsertLendingInformation(string id, string userEmail)
        {
            var lendinginfo = GetLendingInformation(id);
            var itemEntity = this.itemRepository.SelectByID(id);
            lendinginfo.IssueDate = DateTime.Today;

            return true;
        }

        private LendingEntity GetLendingInformation(string itemid)
        {
            var itemEntity = this.itemRepository.SelectByID(itemid);

            var itemLending = new LendingEntity
            {
                

            };

            return itemLending;
        }

        public bool ReturnBorrowedItem(string id, string userEmail)
        {

            var lendingEntity = GetLendingInformation(id);
            if (lendingEntity != null)
            {
               

                return true;
            }
            return false;
        }


    }
}