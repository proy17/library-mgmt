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
        private IViewModelTransalator<BookItemViewModel, BookModel> viewmodelTransalator = null;
        private BookMetadataService bookMetadataService = null;
        private BookService bookService = null;
        private LendingService lendingService = null;
        //
        // GET: /Book/
        public LendingController(
            //BookMetadataService bookMetadataService,
            //BookService bookService,
            )
        {
            this.bookMetadataService = new BookMetadataService();
            this.bookService = new BookService();
            this.viewmodelTransalator= new BookViewModelTransalator();
            this.lendingService = new LendingService();
        }
        //
        // GET: /Lending/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("")]
        public void ReturnItem(BookItemViewModel bookViewModel, string userEmailId)
        {
            this.lendingService.ReturnBorrowedItem(bookViewModel.Id, userEmailId);
        }
        
        public JsonResult BorrowItem(string id, string userEmail)
        {
            Boolean success = false;
            var bookItemModel = this.bookService.SelectByIDandByStatus(id, ItemStatus.Available);
            if (bookItemModel != null)
            {
                bookItemModel.BookStatus = ItemStatus.Borrowed;
                bookService.Insert(bookItemModel);
                this.lendingService.InsertLendingInformation(id, userEmail);
                success = true;
            }
             
            return this.Json(new { success }, JsonRequestBehavior.AllowGet);
            
        }

    }
}
