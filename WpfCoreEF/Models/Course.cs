using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Test.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int? Credits { get; set; }

        public ObservableCollection<Enrollment>? Enrollments { get; set; }
    }
}