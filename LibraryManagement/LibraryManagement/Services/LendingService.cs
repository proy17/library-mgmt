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
    public class LendingService : ILendingService
    {
        public LendingService(
            ItemRepository<BookEntity> itemRepository,
            ITransalator<BookEntity, BookModel> bookTransalator,
            IRepository<LendingEntity> lendingRepository,
            ITransalator<LendingEntity, LendingModel> lendingTransalator)
        {
            this.itemRepository = itemRepository;
            this.bookTransalator = bookTransalator;
            this.lendingRepository = lendingRepository;
            this.lendingTransalator = lendingTransalator;
        }

        private static int count = 100;

        /// <summary>
        /// The book metadata repository.
        /// </summary>
        private ItemRepository<BookEntity> itemRepository = null;

        private IRepository<LendingEntity> lendingRepository = null;


        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<BookEntity, BookModel> bookTransalator = null;

        private ITransalator<LendingEntity, LendingModel> lendingTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public BaseItemModel SelectByID(string id)
        {
            BookEntity itemEntity = (BookEntity)this.itemRepository.SelectByID(id);
            return this.bookTransalator.TransalateToModel(itemEntity);
        }

        public void InsertLendingInformation(string itemId, string userEmail)
        {
            var lendingEntity = new LendingEntity
            {
                IssueDate = DateTime.Today,
                Issuer = userEmail,
                ItemIssued = itemId
            };
            this.lendingRepository.Insert(lendingEntity);
        }

        private LendingEntity GetLendingInformation(string itemId, string userEmail)
        {
            var itemLending = ((LendingRepository)this.lendingRepository).SelectLendingByItemIdAndUserId(userEmail, itemId);

            return itemLending;
        }

        public bool ReturnBorrowedItem(string itemId, string userEmail)
        {
            var lendingEntity = GetLendingInformation(itemId, userEmail);
            this.lendingRepository.Delete(lendingEntity);
            return true;
        }

        public List<LendingModel> SelectAllOverdueLendingInformation(string userId = "")
        {
            var overdueItemsEntities = ((LendingRepository)this.lendingRepository).SelectAllOverdueLendingInformation(userId);
            if (overdueItemsEntities.Any())
            {
                return this.lendingTransalator.TransalateToModels(overdueItemsEntities.ToList()).Cast<LendingModel>().ToList();
            }
            return null;
        }

    }
}