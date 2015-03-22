using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    using LibraryManagement.Enums;
    using LibraryManagement.Entities;
    public abstract class BaseItemEntity : BaseEntity
	{
        public ItemStatus Status { get; set; }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            BaseItemEntity p = obj as BaseItemEntity;
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