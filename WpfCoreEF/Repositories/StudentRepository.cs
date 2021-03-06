using AutoMapper;
using EntityFramework_Test.Data;
using EntityFramework_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace WpfCoreEF.Repositories
{
    public class StudentRepository:IRepository<Student>
    {
        SchoolContext db = null;
        MapperConfiguration config = null;
        Mapper mapper = null;

        public StudentRepository()
        {
            db = new SchoolContext();
            config = new MapperConfiguration(cfg => cfg.CreateMap<Student, Student>());
            mapper = new Mapper(config);
        }

        public void Add(Student Item)
        {
            if (Item != null)
            {
                db.Students.Add(Item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = db.Students.Find(id);
            if (item != null)
            {
                db.Students.Remove(item);
                db.SaveChanges();
            }
        }

        public Student? Get(int id)
        {
            return db.Students.Find(id); 
        }

        public List<Student> GetAll()
        {
            var list = db.Students.ToList();
            return list;
        }

        public bool Update(Student Item)
        {
            var item_find = db.Students.Find(Item.ID);

            if (item_find == null) return false;

            item_find.LastName = Item.LastName;
            item_find.Enrollments = Item.Enrollments;
            item_find.FirstMidName = Item.FirstMidName;
            item_find.EnrollmentDate = Item.EnrollmentDate;
            item_find.Age = Item.Age;

            db.SaveChanges();

            return true;
        }
    }
}
