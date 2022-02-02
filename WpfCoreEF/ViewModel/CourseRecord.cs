using EntityFramework_Test.Models;
using System.Collections.ObjectModel;

namespace WpfCoreEF.ViewModel
{
    public class CourseRecord : ViewModelBase
	{
		private int _courseID;
		public int CourseID
		{
			get
			{
				return _courseID;
			}
			set
			{
				_courseID = value;
				OnPropertyChanged("CourseID");
			}
		}

		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				OnPropertyChanged("Title");
			}
		}

		private int? _credits;
		public int? Credits
		{
			get
			{
				return _credits;
			}
			set
			{
				_credits = value;
				OnPropertyChanged("Credits");
			}
		}

		private ObservableCollection<Enrollment> _enrollments;
		public ObservableCollection<Enrollment> Enrollments
		{
			get
			{
				return _enrollments;
			}
			set
			{
				_enrollments = value;
				OnPropertyChanged("Enrollments");
			}
		}

		private ObservableCollection<Course> _courseRecords;
		public ObservableCollection<Course> CourseRecords
		{
			get
			{
				return _courseRecords;
			}
			set
			{
				_courseRecords = value;
				OnPropertyChanged("CourseRecords");
			}
		}

	}
}
