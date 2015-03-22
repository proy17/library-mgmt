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
    public class RoleService : IRoleService
    {
        public RoleService(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        private IRepository<RoleEntity> roleRepository = null;

        private ITransalator<RoleEntity, RoleModel> roleTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public RoleModel SelectByID(string id)
        {
            var roleEntity = (RoleEntity)this.roleRepository.SelectByID(id);
            return this.roleTransalator.TransalateToModel(roleEntity);
        }

        public bool Insert(RoleModel roleModel)
        {
            try
            {
                var roleEntity = this.roleTransalator.TransalateToEntity(roleModel);
                this.roleRepository.Insert(roleEntity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}