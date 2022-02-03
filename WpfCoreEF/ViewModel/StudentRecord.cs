using EntityFramework_Test.Models;
using System;
using System.Collections.ObjectModel;

namespace WpfCoreEF.ViewModel
{
    public class StudentRecord : ViewModelBase
	{
		private int _ID;
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
				OnPropertyChanged("ID");
			}
		}

		private string _LastName;
		public string LastName
		{
			get
			{
				return _LastName;
			}
			set
			{
				_LastName = value;
				OnPropertyChanged("LastName");
			}
		}

		private string _FirstMidName;
		public string FirstMidName
		{
			get
			{
				return _FirstMidName;
			}
			set
			{
				_FirstMidName = value;
				OnPropertyChanged("FirstMidName");
			}
		}
		
		private DateTime? _EnrollmentDate;
		public DateTime? EnrollmentDate
		{
			get
			{
				return _EnrollmentDate;
			}
			set
			{
				_EnrollmentDate = value;
				OnPropertyChanged("EnrollmentDate");
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

		private ObservableCollection<Student> _StudentRecords;
		public ObservableCollection<Student> StudentRecords
		{
			get
			{
				return _StudentRecords;
			}
			set
			{
				_StudentRecords = value;
				OnPropertyChanged("StudentRecords");
			}
		}

	}
}
