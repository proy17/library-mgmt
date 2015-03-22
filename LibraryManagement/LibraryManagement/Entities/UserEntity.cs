using LibraryManagement.Entities;
using LibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }


        public string UserEmail { get; set; }

        public RoleEnums RoleId { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            UserEntity p = obj as UserEntity;
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