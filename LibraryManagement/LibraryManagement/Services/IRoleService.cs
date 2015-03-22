using System;
using System.Collections.Generic;
using System.Linq;


namespace LibraryManagement.Services
{
    using LibraryManagement.DAL.EntityModelTranslator;
    using LibraryManagement.DAL;
    using LibraryManagement.DAL.Repositories;
    using LibraryManagement.DAL.ViewModelTransalator;
    using LibraryManagement.Entities;
    using LibraryManagement.Models;
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.Enums;
    using LibraryManagement.ViewModels;

    public interface IRoleService : IService
    {
        RoleModel SelectByID(string id);
        bool Insert(RoleModel roleModel);
    }
}