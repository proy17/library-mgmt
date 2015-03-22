using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class TemplateController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.Title = "Welcome to Liberty Public Library";
            return View();
        }

        public ViewResult BookDetailsTmpl()
        {
            return View("_BookDetails");
        }

        public ViewResult BookSearchTmpl()
        {
            return View("_BookSearch");
        }

        public ViewResult OverdueBooksTmpl()
        {
            return View("_OverdueBooks");
        }
        public ViewResult LoginTmpl()
        {
            return View("_Login");
        }

        public ViewResult RegisterTmpl()
        {
            return View("_Register");
        }

        public ViewResult AddBookTmpl()
        {
            return View("_AddBook");
        }
    }
}
