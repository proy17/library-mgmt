using LibraryManagement.DAL.ViewModelTransalator;
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
    public class BookController : Controller
    {
        private IViewModelTransalator<BookItemViewModel, BookModel> viewmodelTransalator = null;
        private BookMetadataService bookMetadataService = null;
        private BookService bookService = null;
        private LendingService lendingService = null;
        //
        // GET: /Book/
        public BookController(
            //BookMetadataService bookMetadataService,
            //BookService bookService,
            )
        {
            this.bookMetadataService = new BookMetadataService();
            this.bookService = new BookService();
            this.viewmodelTransalator= new BookViewModelTransalator();
            this.lendingService = new LendingService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InserBook(BookItemViewModel bookViewModel, int numberofInstances)
        {
            var bookMetadata = this.bookMetadataService.GetAllBookMetadatasByName(bookViewModel.BookMetaDataModel.Author);
            var bookModel = new BookModel();
            
            if (bookMetadata != null)
            {
                bookModel = this.viewmodelTransalator.TransalateToModel(bookViewModel);

            }
            //if the book is been entered in the library for the first time, hence has no book metadata stored
            else
            {
                this.bookMetadataService.Insert(bookMetadata);
            }
           
            bookService.Insert(bookModel);
            return null;
        }
    }
}
