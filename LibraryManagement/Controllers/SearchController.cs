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

    public class SearchController : Controller
    {
        private IViewModelTransalator<LendingViewModel, LendingModel> lendingviewModelTransalator = null;
        private IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> bookMetadataViewModelTransalator = null;
        private BookMetadataService bookMetadataService = null;
        private BookService bookService = null;
        private SearchService searchService = null;
        public SearchController()
        {
            this.lendingviewModelTransalator = new LendingViewModelTransalator();
            this.bookMetadataViewModelTransalator = new BookMetadataViewModelTransalator();
            this.bookMetadataService = new BookMetadataService();
            this.searchService = new SearchService();

        }
        public ActionResult Index()
        {
            // var result = GetAllResults();
            ViewBag.Title = "Welcome to Liberty Public Library";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "Liberty Library";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        public ViewResult GetAllResults()
        {
            var bookMetaDataModels = this.bookMetadataService.GetAllBookMetadatas();
            var bookMetadataViewModels = (from model in bookMetaDataModels select this.bookMetadataViewModelTransalator.TransalateToViewModel(model)).ToList();
            ViewBag.BookMetadatas = new JavaScriptSerializer().Serialize(bookMetadataViewModels);
            return View("_BookSearch");
        }

        public JsonResult GetResultsByName(string id)
        {
            var bookMetaDataModel = this.bookMetadataService.GetAllBookMetadatasByName(id);
            var bookMetadataViewModel = this.bookMetadataViewModelTransalator.TransalateToViewModel(bookMetaDataModel);
            return this.Json(new { bookMetadataViewModel }, JsonRequestBehavior.AllowGet);
        }

        public ViewResult BookDetailsTmpl()
        {
            return View("_BookDetails");
        }

        public ViewResult BookSearchTmpl()
        {
            return View("_BookSearch");
        }

        public JsonResult SearchOverdueBooks()
        {
            var bookMetaDataModels = this.bookMetadataService.GetAllBookMetadatas();
            var bookMetadataViewModels = (from model in bookMetaDataModels select this.bookMetadataViewModelTransalator.TransalateToViewModel(model)).ToList();
            return this.Json(new { bookMetadataViewModels }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOverDueItemInformation()
        {
            var overDueItems = this.searchService.GetAllOverDueItemsInformation();
            var viewModels =
                (from model in overDueItems.ToList()
                 select this.lendingviewModelTransalator.TransalateToViewModel(model)).ToList();
            return this.Json(new { viewModels }, JsonRequestBehavior.AllowGet);
        }
    }
}
