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

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            var list = _repository.GetAll();
            if(list == null)
            {
                Assert.Fail();
                return;
            }               
            var obj = list[0];
            var find_obj = _repository.Get(obj.CourseID);
            Assert.IsNotNull(obj);
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
            var list = _repository.GetAll();
            if (list == null)
            {
                Assert.Fail();
                return;
            }
            var obj = list[0];
            
            // Caching "Credits"
            var tmp_credits = obj.Credits;
            obj.Credits = 0;
            Assert.IsTrue(_repository.Update(obj));

            // Reset "Credits"
            obj.Credits = tmp_credits;
            _repository.Update(obj);
        }
    }
}