﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Project
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int? CustomerID { get; set; }
        public int? StaffID { get; set;}
        public int? ManagerID { get; set;}
    }
}
