using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalendar;
using MyCalendar.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyCalendar.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

        }

        [TestMethod]
        public void CalendarIndex()
        {
            // Arrange
            CalendarsController controller = new CalendarsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CategoryTaskIndex()
        {
            // Arrange
            CategoryTasksController controller = new CategoryTasksController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EventsIndex()
        {

            // Arrange
            EventsController controller = new EventsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NotificationsIndex()
        {

            // Arrange
            NotificationsController controller = new NotificationsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void OrganizationsIndex()
        {
            // Arrange
            OrganizationsController controller = new OrganizationsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UsersIndex()
        {
            // Arrange
            UsersController controller = new UsersController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
