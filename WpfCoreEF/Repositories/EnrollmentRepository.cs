using EntityFramework_Test.Data;
using EntityFramework_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace WpfCoreEF.Repositories
{
    public class EnrollmentRepository:IRepository<Enrollment>
    {
        SchoolContext db = null;

        public EnrollmentRepository()
        {
            db = new SchoolContext();
        }

        public void Add(Enrollment Item)
        {
            if (Item != null)
            {
                db.Enrollments.Add(Item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = db.Enrollments.Find(id);
            if (item != null)
            {
                db.Enrollments.Remove(item);
                db.SaveChanges();
            }
        }

        public Enrollment? Get(int id)
        {
            return db.Enrollments.Find(id); 
        }

        public List<Enrollment> GetAll()
        {
            var list = db.Enrollments.ToList();
            return list;
        }

        public void Update(Enrollment Item)
        {
            var item_find = db.Enrollments.Find(Item.EnrollmentID);

            if (item_find == null) return;

            item_find.Grade = Item.Grade;
            item_find.StudentID = Item.StudentID;
            item_find.EnrollmentID = Item.EnrollmentID;
            item_find.CourseID = Item.CourseID;
            item_find.Course = Item.Course;
            item_find.Student = Item.Student;
            db.SaveChanges();
        }
    }
}
