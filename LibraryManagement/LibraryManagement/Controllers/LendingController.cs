using LibraryManagement.DAL.ViewModelTransalator;
using LibraryManagement.Enums;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class LendingController : Controller
    {
        private IBookService bookService = null;
        private ILendingService lendingService = null;
        private IBookMetadataService bookMetadataService;
        //
        // GET: /Book/
        public LendingController(IBookService bookService, ILendingService lendingService, IBookMetadataService bookMetadataService)
        {
            this.bookMetadataService = bookMetadataService;
            this.bookService = bookService;
            this.lendingService = lendingService;
        }
        //
        // GET: /Lending/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        /// <summary>
        /// Return book item based on id and username
        /// </summary>
        /// <param name="bookMetadataId"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public JsonResult ReturnItem(string bookMetadataId, string userEmail)
        {
            Boolean success = false;
            var bookModel = this.bookService.SelectBookByMetadataId(bookMetadataId, ItemStatus.Borrowed); 
            if (bookModel != null)
            {
                this.lendingService.ReturnBorrowedItem(bookModel.ID, userEmail);
                bookModel.BookStatus = ItemStatus.Available;
               
                success = this.bookService.Update(bookModel);                
            } 
             
            return this.Json(new { success }, JsonRequestBehavior.AllowGet);            
        }
        /// <summary>
        /// borrow item
        /// </summary>
        /// <param name="bookMetadataId"></param>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public JsonResult BorrowItem(string bookMetadataId, string userEmail)
        {
            Boolean success = false;
            var bookModel = this.bookService.SelectBookByMetadataId(bookMetadataId, ItemStatus.Available);
            if (bookModel != null)
            {
                this.lendingService.InsertLendingInformation(bookModel.ID, userEmail);
                bookModel.BookStatus = ItemStatus.Borrowed;
                success = this.bookService.Update(bookModel);                
            } 
             
            return this.Json(new { success }, JsonRequestBehavior.AllowGet);
            
        }

    }
}
