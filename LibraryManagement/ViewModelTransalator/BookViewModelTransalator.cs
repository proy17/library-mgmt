using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;

    public class BookViewModelTransalator : IViewModelTransalator<BookItemViewModel, BookModel>
    {
        private IViewModelTransalator<BookMetadataViewModel, BookMetadataModel> transalator = null;

        public BookModel TransalateToModel(BookItemViewModel bookviewModel)
        {
            var bookModel = new BookModel
            {
                BookMetaDataModel = this.transalator.TransalateToModel(bookviewModel.BookMetaDataModel),
                Id = bookviewModel.Id,
                ID = bookviewModel.ID
            };
            return bookModel;
        }
        public BookItemViewModel TransalateToViewModel(BookModel bookModel)
        {
            var bookViewModel = new BookItemViewModel
            {
                BookMetaDataModel = this.transalator.TransalateToViewModel(bookModel.BookMetaDataModel),
                ID = bookModel.ID
            };
            return bookViewModel;
        }
    }
}