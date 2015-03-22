using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.DAL.Entities
{
    public class UserEntity: BaseEntity
    {
        
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Roleid { get; set; }

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