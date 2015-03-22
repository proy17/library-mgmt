using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;

    public class BookMetadataViewModelTransalator : IViewModelTransalator<BookMetadataViewModel, BookMetadataModel>
    {
        public BookMetadataModel TransalateToModel(BookMetadataViewModel bookMetadataViewModel)
        {
           
             var   MetaData = new BookMetadataModel
                {
                    ID = bookMetadataViewModel.ID,
                    Author = bookMetadataViewModel.Author,
                    BookId = bookMetadataViewModel.BookId,
                    BookName = bookMetadataViewModel.BookName
                };
             return MetaData;
               
        }
        public BookMetadataViewModel TransalateToViewModel(BookMetadataModel bookMetadataModel)
        {
            var bookMetaData = new BookMetadataViewModel
                {
                    ID = bookMetadataModel.ID,
                    Author = bookMetadataModel.Author,
                    BookId = bookMetadataModel.BookId,
                    BookName = bookMetadataModel.BookName
                };
          
            return bookMetaData;
        }
    }
}