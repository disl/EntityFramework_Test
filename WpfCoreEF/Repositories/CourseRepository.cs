using AutoMapper;
using EntityFramework_Test.Data;
using EntityFramework_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace WpfCoreEF.Repositories
{
    public class CourseRepository:IRepository<Course>
    {
        SchoolContext db;
        MapperConfiguration config =null;
        Mapper mapper = null;

        public CourseRepository()
        {
            db = new SchoolContext();

            config = new MapperConfiguration(cfg => cfg.CreateMap<Course, Course>());
            mapper = new Mapper(config);
        }

        public void Add(Course Item)
        {
            if (Item != null)
            {
                db.Courses.Add(Item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = db.Courses.Find(id);
            if (item != null)
            {
                db.Courses.Remove(item);
                db.SaveChanges();
            }
        }

        public Course? Get(int id)
        {
            return db.Courses.Find(id); 
        }

        public List<Course> GetAll()
        {
            var list = db.Courses.ToList();
            return list;
        }

        public bool Update(Course Item)
        {
            var item_find = db.Courses.Find(Item.CourseID);

            if (item_find == null) return false;

            mapper.Map<Course,Course>(Item, item_find);

            //item_find.CourseID=Item.CourseID;
            //item_find.Title = Item.Title;
            //item_find.Enrollments = Item.Enrollments;
            //item_find.CourseID = Item.CourseID;
            //item_find.Credits = Item.Credits;

            db.SaveChanges();

            return true;
        }
    }
}
