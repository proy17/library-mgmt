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
                    BookName = bookMetadataViewModel.BookName,
                    BookVersion = bookMetadataViewModel.BookVersion,
                    Language=bookMetadataViewModel.Language,
                    Publisher=bookMetadataViewModel.Publisher
                };
             return MetaData;
               
        }
        public BookMetadataViewModel TransalateToViewModel(BookMetadataModel bookMetadataModel)
        {
            var bookMetaData = new BookMetadataViewModel
                {
                    ID = bookMetadataModel.ID,
                    Author = bookMetadataModel.Author,
                    BookName = bookMetadataModel.BookName,
                    BookVersion = bookMetadataModel.BookVersion,
                    Language = bookMetadataModel.Language,
                    Publisher = bookMetadataModel.Publisher
                };
          
            return bookMetaData;
        }
    }
}