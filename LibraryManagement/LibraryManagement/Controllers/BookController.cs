using LibraryManagement.DAL.ViewModelTransalator;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> bookMetadataViewModelTransalator = null;
        private IBookMetadataService bookMetadataService = null;
        private IBookService bookService = null;

        public BookController(IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> bookMetadataViewModelTransalator,
            IBookMetadataService bookMetadataService,
            IBookService bookService)
        {
            this.bookMetadataViewModelTransalator = bookMetadataViewModelTransalator;
            this.bookMetadataService = bookMetadataService;
            this.bookService = bookService;
        }

        [HttpPost]
        public JsonResult InsertBook(string formInfo)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            BookMetadataViewModel bookmetadataViewModel = jss.Deserialize<BookMetadataViewModel>(formInfo);
            var bookMetadata = this.bookMetadataService.GetAllBookMetadatasByName(bookmetadataViewModel.BookName);
            var bookMetadataModel = this.bookMetadataViewModelTransalator.TransalateToModel(bookmetadataViewModel);            
            //if the book is been entered in the library for the first time, hence has no book metadata stored
            if (bookMetadata == null)
            {
              bookMetadataModel =  this.bookMetadataService.Insert(bookMetadataModel);
            }
            var bookModel = new BookModel
            {
                BookMetaDataModel = bookMetadataModel,
                BookStatus = Enums.ItemStatus.Available                
            };
            bookService.Insert(bookModel);
            return this.Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
