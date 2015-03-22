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
          return  TestData.MetadataEntities;
        }
        public BaseMetadataEntity SelectByID(string id)
        {
            return TestData.metadataEntities.Find(item => item.ID == id);
        }
        public void Insert(BaseMetadataEntity obj)
        {
            TestData.metadataEntities.Add(obj);
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
