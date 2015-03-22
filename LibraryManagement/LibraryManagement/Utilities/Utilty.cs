using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryManagement.Utilities
{
    public static class Utilty
    {
        private static int nextId = 100;
        public static int GenerateRandomId()
        {
            return nextId++;
        }
    }
}