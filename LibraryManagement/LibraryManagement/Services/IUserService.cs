using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.DAL.EntityModelTranslator;

namespace LibraryManagement.Services
{
    using LibraryManagement.DAL;
    using LibraryManagement.DAL.Repositories;
    using LibraryManagement.DAL.ViewModelTransalator;
    using LibraryManagement.Entities;
    using LibraryManagement.Models;
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.Enums;
    using LibraryManagement.ViewModels;

    /// <summary>
    /// The book metadata service.
    /// </summary>
    public interface IUserService : IService
    {
        UserModel SelectByID(string id);
        bool Insert(UserModel userModel);
    }
}