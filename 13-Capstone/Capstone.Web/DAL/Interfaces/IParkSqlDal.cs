using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Capstone.Web.DAL.Interfaces
{
    public interface IParkSqlDal
    {
        Park GetParkDetail(string parkCode);
        List<Park> GetParks();
        List<SelectListItem>GetParkSelectList();
        List<SelectListItem> GetStateSelectList();
    }
}

