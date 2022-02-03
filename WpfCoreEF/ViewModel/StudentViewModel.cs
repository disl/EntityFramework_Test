using EntityFramework_Test.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfCoreEF.Repositories;

namespace WpfCoreEF.ViewModel
{
    public class StudentViewModel
	{
		private ICommand _saveCommand;
		private ICommand _resetCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;
		private StudentRepository _repository;
		
		private Student _StudentEntity = null;
		public StudentRecord StudentRecord { get; set; }

		public ICommand ResetCommand
		{
			get
			{
				if (_resetCommand == null)
					_resetCommand = new RelayCommand(param => ResetData(), null);

				return _resetCommand;
			}
		}

		public ICommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
					_saveCommand = new RelayCommand(param => SaveData(), null);

				return _saveCommand;
			}
		}

		public ICommand EditCommand
		{
			get
			{
				if (_editCommand == null)
					_editCommand = new RelayCommand(param => EditData((int)param), null);

				return _editCommand;
			}
		}

		public ICommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
					_deleteCommand = new RelayCommand(param => DeleteStudent((int)param), null);

				return _deleteCommand;
			}
		}

		public StudentViewModel()
		{
			_StudentEntity = new Student();
			_repository = new StudentRepository();
			StudentRecord = new StudentRecord();
			GetAll();
		}

		public void ResetData()
		{
			StudentRecord.LastName = null;
			StudentRecord.FirstMidName = null;
			StudentRecord.EnrollmentDate = null;
			//StudentRecord.Enrollments = null;
		}

		public void DeleteStudent(int id)
		{
			if (MessageBox.Show("Confirm delete of this record?", "Student", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					_repository.Delete(id);
					MessageBox.Show("Record successfully deleted.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error occured while saving. " + ex.InnerException);
				}
				finally
				{
					GetAll();
				}
			}
		}

		public void SaveData()
		{
			if (StudentRecord != null)
			{
				_StudentEntity.LastName = StudentRecord.LastName;
				_StudentEntity.FirstMidName = StudentRecord.FirstMidName;
				_StudentEntity.EnrollmentDate = StudentRecord.EnrollmentDate;
				_StudentEntity.Enrollments = StudentRecord.Enrollments;

				try
				{
					if (StudentRecord.ID <= 0)
					{
						_repository.Add(_StudentEntity);
						MessageBox.Show("New record successfully saved.");
					}
					else
					{
						_StudentEntity.ID = StudentRecord.ID;
						_repository.Update(_StudentEntity);
						MessageBox.Show("Record successfully updated.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error occured while saving. " + ex.InnerException);
				}
				finally
				{
					GetAll();
					ResetData();
				}
			}
		}

		public void EditData(int id)
		{
			var model = _repository.Get(id);

			StudentRecord.ID = model.ID;
			StudentRecord.LastName = model.LastName;
			StudentRecord.FirstMidName = model.FirstMidName;
			StudentRecord.EnrollmentDate = model.EnrollmentDate;

			//if(model.Enrollments != null)
			//StudentRecord.Enrollments = model.Enrollments;
		}

		public void GetAll()
		{
			StudentRecord.StudentRecords = new ObservableCollection<Student>();
			_repository.GetAll().ForEach(data => StudentRecord.StudentRecords.Add(new Student()
			{
				ID = data.ID,
			LastName = data.LastName,
			FirstMidName = data.FirstMidName,
			EnrollmentDate = data.EnrollmentDate,
			}));
		}
	}
}
