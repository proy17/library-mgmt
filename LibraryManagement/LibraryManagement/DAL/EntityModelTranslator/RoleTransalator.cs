using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.EntityModelTranslator
{
    public class RoleTransalator : ITransalator<RoleEntity, RoleModel>
    {
        /// <summary>
        /// The transalate to model.
        /// </summary>
        /// <param name="roleEntity">
        /// The book entity.
        /// </param>
        /// <returns>
        /// The <see cref="UserModel"/>.
        /// </returns>
        public RoleModel TransalateToModel(RoleEntity roleEntity)
        {
            var roleModel = new RoleModel
            {
                ID = roleEntity.ID,
                RoleName = roleEntity.RoleName
            };
            return roleModel;
        }
                
        /// <summary>
        /// The transalate to entity.
        /// </summary>
        /// <param name="roleModel">
        /// The book model.
        /// </param>
        /// <returns>
        /// The <see cref="UserEntity"/>.
        /// </returns>
        public RoleEntity TransalateToEntity(RoleModel roleModel)
        {
            var roleEntity = new RoleEntity
            {
                ID = roleModel.ID,
                RoleName = roleModel.RoleName

            };
            return roleEntity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleModels"></param>
        /// <returns></returns>
        public List<RoleEntity> TransalateToEntities(List<RoleModel> roleModels)
        {
            var roleEntities = (from model in roleModels
                                select TransalateToEntity(model)).ToList();
            return roleEntities;
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
        public List<RoleModel> TransalateToModels(List<RoleEntity> roleEntities)
        {
            var roleModels = (from entity in roleEntities
                              select TransalateToModel(entity)).ToList();
            return roleModels;
        }
    }
}