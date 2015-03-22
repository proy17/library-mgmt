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
    public class UserService : IUserService
    {
        public UserService(
            IRepository<UserEntity> userRepository,
            IRepository<RoleEntity> roleRepository,
            ITransalator<UserEntity, UserModel> userTransalator)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userTransalator = userTransalator;
        }
        private IRepository<UserEntity> userRepository = null;
        private IRepository<RoleEntity> roleRepository = null;

        /// <summary>
        /// The book metadata transalator.
        /// </summary>
        private ITransalator<UserEntity, UserModel> userTransalator = null;

        /// <summary>
        /// The get all book metadatas.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public UserModel SelectByID(string id)
        {
            var userEntity = (UserEntity)this.userRepository.SelectByID(id);
            if (userEntity != null)
            {
                return this.userTransalator.TransalateToModel(userEntity);
            }
            return null;
        }
       /// <summary>
       /// Insert
       /// </summary>
       /// <param name="userModel"></param>
       /// <returns></returns>
        public bool Insert(UserModel userModel)
        {
            try
            {
                var userEntity = this.userTransalator.TransalateToEntity(userModel);
                this.userRepository.Insert(userEntity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}