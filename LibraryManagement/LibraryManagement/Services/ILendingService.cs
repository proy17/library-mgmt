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
    public interface ILendingService : IService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BaseItemModel SelectByID(string id);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userEmail"></param>
        void InsertLendingInformation(string itemId, string userEmail);
         /// <summary>
         /// 
         /// </summary>
         /// <param name="itemId"></param>
         /// <param name="userEmail"></param>
         /// <returns></returns>
       
        bool ReturnBorrowedItem(string itemId, string userEmail);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<LendingModel> SelectAllOverdueLendingInformation(string userId = "");


    }
}