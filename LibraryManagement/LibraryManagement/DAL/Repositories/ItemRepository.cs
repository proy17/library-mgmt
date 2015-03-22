// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepository.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IItemRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using System;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.Enums;
    using LibraryManagement.TestData;
    /// <summary>
    /// The ItemRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public abstract class ItemRepository<TEntity> : IRepository<BaseItemEntity>        
        where TEntity: BaseItemEntity
    {
        public BaseItemEntity SelectByID(string id)
        {
            return TestData.itemEntities.Find(item => item.ID == id);
        }

        public IEnumerable<BaseItemEntity> SelectAll()
        {
            return TestData.itemEntities;
        }


        public BaseItemEntity Insert(BaseItemEntity obj)
        {
            obj.ID = Convert.ToString(Utilities.Utilty.GenerateRandomId());
            TestData.itemEntities.Add(obj);
            return obj;
        }

        public void Update(BaseItemEntity obj)
        {
            TestData.itemEntities.Remove(obj);
            TestData.itemEntities.Add(obj);
        }

        public void Delete(BaseItemEntity obj)
        {
            TestData.itemEntities.Remove(obj);
        }

        public abstract TEntity SelectByIDandByStatus(string itemId, ItemStatus itemStatus);

        public abstract List<TEntity> SelectAllByStatus(ItemStatus itemStatus);

        public abstract TEntity SelectItemByMetadataId(string metadataId, ItemStatus itemStatus);
    }
}
