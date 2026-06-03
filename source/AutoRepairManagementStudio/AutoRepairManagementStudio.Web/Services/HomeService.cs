using AutoRepairManagementStudio.DataAccessLayer;
using AutoRepairManagementStudio.DataAccessLayer.Entities;
using AutoRepairManagementStudio.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoRepairManagementStudio.Web.Services
{
    public class HomeService
    {
        public HomeService(AutoRepairContext context)
        {
            DataAccess = new AutoRepairDA(context);
        }

        #region Data Members
        private AutoRepairDA DataAccess { get; }
        #endregion Data Members


    }
}
