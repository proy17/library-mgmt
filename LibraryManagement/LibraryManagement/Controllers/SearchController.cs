using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.DAL.Repositories;
using LibraryManagement.DAL.Entities;
using System.Web.Script.Serialization;

namespace LibraryManagement.Controllers
{
    using LibraryManagement.DAL.EntityModelTranslator;
    using LibraryManagement.DAL.ViewModelTransalator;
    using LibraryManagement.Models;
    using LibraryManagement.Services;
    using LibraryManagement.ViewModels;
    using LibraryManagement.Enums;

    public class SearchController : Controller
    {
        private IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> bookMetadataViewModelTransalator;
        private IBookMetadataService bookMetadataService;
        private IBookService bookService;
        private ILendingService lendingService;
        private IUserService userService;

        public SearchController(
            IUserService userService,
            IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> bookMetadataViewModelTransalator,
            IBookMetadataService bookMetadataService,
            ILendingService lendingService,
            IBookService bookService)
        {
            this.userService = userService;
            this.bookMetadataViewModelTransalator = bookMetadataViewModelTransalator;
            this.bookMetadataService = bookMetadataService;
            this.bookService = bookService;
            this.lendingService = lendingService;
        }
           
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllResults()
        {
            var bookMetadataModels = this.bookMetadataService.GetAllBookMetadatas();

            foreach (var bookMetadataModel in bookMetadataModels)
            {
                bookMetadataModel.Available = this.bookService.isAvailable(bookMetadataModel.ID);
            }

            return this.Json(new { bookMetadataModels }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetResultsByName(string id)
        {
            var bookMetaDataModel = this.bookMetadataService.GetAllBookMetadatasByName(id);
            var bookMetadataViewModel = this.bookMetadataViewModelTransalator.TransalateToViewModel(bookMetaDataModel);
            return this.Json(new { bookMetadataViewModel }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public JsonResult SearchOverdueBooks(string userEmail, string role)
        {
            List<BookMetadataViewModel> bookMetadataViewModels = new List<BookMetadataViewModel>();
            List<LendingModel> lendingModels = new List<LendingModel>();

            //check if the role is not admin
            if (!role.Equals(RoleEnums.Admin.ToString()))
            {
                //get the lending models for this user only
                UserModel userModel = this.userService.SelectByID(userEmail);
                lendingModels = this.lendingService.SelectAllOverdueLendingInformation(userModel.ID);
            }
            //get the lending modelsfor all the users
            else lendingModels = this.lendingService.SelectAllOverdueLendingInformation();

            //for each lendign model find the book metadata
            if (lendingModels != null)
            {
                foreach (var lendingModel in lendingModels)
                {
                    var bookItem = this.bookService.SelectByBookID(lendingModel.ItemIssued);
                    BookMetadataViewModel bookMVM = this.bookMetadataViewModelTransalator.TransalateToViewModel(bookItem.BookMetaDataModel);
                    bookMVM.IssueDate = lendingModel.Issuedate.ToShortDateString();
                    bookMetadataViewModels.Add(bookMVM);
                }
            }

            return this.Json(new { bookMetadataViewModels }, JsonRequestBehavior.AllowGet);
        }
    }
}
