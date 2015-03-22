using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.EntityModelTranslator
{
    public class UserTransalator: ITransalator<UserEntity,UserModel>
    {
        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="UserEntity">
        /// The book entity.
        /// </param>
        /// <returns>
        /// The <see cref="UserModel"/>.
        /// </returns>
        public UserModel TransalateToModel(UserEntity UserEntity)
        {
            var UserModel = new UserModel
            {
                ID = UserEntity.ID,
                Password = UserEntity.Password,
                UserEmail=UserEntity.UserEmail,
                Roleid = UserEntity.Roleid
            };
            return UserModel;
        }

       

        /// <summary>
        /// The transalate to entity.
        /// </summary>
        /// <param name="UserModel">
        /// The book model.
        /// </param>
        /// <returns>
        /// The <see cref="UserEntity"/>.
        /// </returns>
        public UserEntity TransalateToEntity(UserModel UserModel)
        {
            var UserEntity = new UserEntity
            {                
                ID = UserModel.ID,
                Roleid=UserModel.Roleid,
                UserEmail=UserModel.UserEmail,
                Password=UserModel.Password
               
            };
            return UserEntity;
        }
        public List<UserEntity> TransalateToEntities(List<UserModel> userModels)
        {
            var userEntities = (from model in userModels
                                select TransalateToEntity(model)).ToList();
            return userEntities;
        }

        /// <summary>
        /// The transalate to models.
        /// </summary>
        /// <param name="userEntity">
        /// The book metadata entity.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<UserModel> TransalateToModels(List<UserEntity> userEntities)
        {
            var userModels = (from entity in userEntities
                              select TransalateToModel(entity)).ToList();
            return userModels;
        }
    }
}