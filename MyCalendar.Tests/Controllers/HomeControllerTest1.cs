using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar.Tests.Controllers
{
    [TestClass]
    class HomeControllerTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CategoryTask student = new CategoryTask();
            Assert.IsNotNull(student);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Notification teacher = new Notification();
            Assert.IsNotNull(teacher);

        }
        [TestMethod]
        public void TestMethod3()
        {
            Organization subject = new Organization();
            Assert.IsNotNull(subject);

        }
        [TestMethod]
        public void TestMethod4()
        {
            Calendar schedule = new Calendar();
            Assert.IsNotNull(schedule);

        }
        [TestMethod]
        public void TestMethod5()
        {
            Event student = new Event();
            Assert.IsNotNull(student);

        }


        [TestMethod]
        public void TestMethod6()
        {
            User student = new User();
            Assert.IsNotNull(student);

        }
    }
}
