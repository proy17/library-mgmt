
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL
{
    using LibraryManagement.Entities;
    public abstract class BaseMetadataEntity : BaseEntity
    {
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            BaseMetadataEntity p = obj as BaseMetadataEntity;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == p.ID);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ ID.GetHashCode();
        }
    }
}