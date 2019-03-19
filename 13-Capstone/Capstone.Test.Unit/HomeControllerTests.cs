using System;
using Capstone.Web.Controllers;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Test.Unit
{
    public class HomeControllerTest
    {
        private readonly string connectionString;
        private HomeController controller;
        private IParkSqlDal parkSqlDal = new ParkSqlDal(connectionString);
        private IForecastSqlDal forecastSqlDal = new ForecastSqlDal(connectionString);

        public void ParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        [TestInitialize]
        public void Initialize()
        {
            controller = new HomeController(parkSqlDal);
        }

        [TestClass]
        public class Index : FriendsControllerTest
        {
            [TestMethod]
            public void It_returns_a_View_based_on_the_action_name()
            {
                IActionResult result = controller.Index() as ViewResult;
                AssertViewResultIs(nameof(controller.Index), (ViewResult)result);
            }
        }

        [TestClass]
        public class New_GET : FriendsControllerTest
        {
            [TestMethod]
            public void It_returns_a_View_based_on_the_action_name()
            {
                var result = controller.New() as ViewResult;
                AssertViewResultIs(nameof(controller.New), result);
            }
        }

        [TestClass]
        public class New_POST : FriendsControllerTest
        {
            [TestMethod]
            public void It_returns_a_View_based_on_the_action_name()
            {
                ActionContext actionContext = new ActionContext();
                var model = new NewFriendViewModel();
                var result = controller.New(model) as ViewResult;
                AssertViewResultIs(nameof(controller.New), result);
            }
        }

        protected void AssertViewResultIs(string action, ViewResult viewResult)
        {
            Assert.IsTrue(viewResult.ViewName == null ||
                viewResult.ViewName.Equals(action, StringComparison.InvariantCultureIgnoreCase),
                $"Result.ViewName was {viewResult.ViewName}, but expected null or {action}.");
        }
    }

}
}

