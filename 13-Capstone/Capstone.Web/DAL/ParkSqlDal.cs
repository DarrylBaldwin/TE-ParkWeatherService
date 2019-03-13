﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Web.DAL
{
    public class ParkSqlDal : IParkSqlDal
    {

        private readonly string connectionString;

        
        public ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
