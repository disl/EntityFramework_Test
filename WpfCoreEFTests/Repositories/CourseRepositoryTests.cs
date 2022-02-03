using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfCoreEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_Test.Data;

namespace WpfCoreEF.Repositories.Tests
{
    [TestClass()]
    public class CourseRepositoryTests
    {
        private CourseRepository _repository = new CourseRepository ();

        //SchoolContext db = null;

        //public CourseRepository()
        //{
        //    db = new SchoolContext();
        //}

        [TestMethod()]
        public void CourseRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var obj = _repository.GetAll();
            Assert.IsTrue(obj != null);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}