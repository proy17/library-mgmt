using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.TestData;
    public abstract class MetadataRepository<TEntity> : IRepository<BaseMetadataEntity>
        where TEntity : BaseMetadataEntity
    {
        public IEnumerable<BaseMetadataEntity> SelectAll()
        {
          return  TestData.metadataEntities;
        }
        public BaseMetadataEntity SelectByID(string id)
        {
            return TestData.metadataEntities.Find(item => item.ID == id);
        }
        public BaseMetadataEntity Insert(BaseMetadataEntity obj)
        {
            obj.ID = Convert.ToString(Utilities.Utilty.GenerateRandomId());
            TestData.metadataEntities.Add(obj);
            return obj;
        }
        public void Update(BaseMetadataEntity obj)
        {
            TestData.metadataEntities.Remove(obj);
            TestData.metadataEntities.Add(obj);
        }
        public void Delete(BaseMetadataEntity obj)
        {
            TestData.metadataEntities.Remove(obj);
        }

        public abstract TEntity SelectByName(string name);
        
    }
}
