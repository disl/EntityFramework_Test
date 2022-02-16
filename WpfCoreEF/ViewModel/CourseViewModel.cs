using AutoMapper;
using EntityFramework_Test.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfCoreEF.Repositories;

namespace WpfCoreEF.ViewModel
{
    public class CourseViewModel
	{
		private ICommand _saveCommand;
		private ICommand _resetCommand;
		private ICommand _editCommand;
		private ICommand _deleteCommand;
		private CourseRepository _repository;
		private Course _CourseEntity = null;

		MapperConfiguration config = null;
		Mapper mapper = null;
		public CourseViewModel()
		{
			

			_CourseEntity = new Course();
			_repository = new CourseRepository();
			CourseRecord = new CourseRecord();
			GetAll();
		}

		public CourseRecord CourseRecord { get; set; }

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
					_deleteCommand = new RelayCommand(param => DeleteCourse((int)param), null);

				return _deleteCommand;
			}
		}

		

		public void ResetData()
		{
			CourseRecord.CourseID = 0;
			CourseRecord.Title = null;
			CourseRecord.Credits = 0;
			//CourseRecord.Enrollments = null;
		}

		public void DeleteCourse(int id)
		{
			if (MessageBox.Show("Confirm delete of this record?", "Course", MessageBoxButton.YesNo)
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
			if (CourseRecord != null)
			{
				config = new MapperConfiguration(cfg => cfg.CreateMap<CourseRecord, Course>());
				mapper = new Mapper(config);

				mapper.Map<CourseRecord, Course>(CourseRecord, _CourseEntity);

                //_CourseEntity.CourseID = CourseRecord.CourseID;
                //_CourseEntity.Title = CourseRecord.Title;
                //_CourseEntity.Credits = CourseRecord.Credits;
                //_CourseEntity.Enrollments = CourseRecord.Enrollments;

                try
				{
					if (CourseRecord.CourseID <= 0)
					{
						_repository.Add(_CourseEntity);
						//MessageBox.Show("New record successfully saved.");
					}
					else
					{
						_CourseEntity.CourseID = CourseRecord.CourseID;
						_repository.Update(_CourseEntity);
						//MessageBox.Show("Record successfully updated.");
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

			mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseRecord>()));
			mapper.Map<Course, CourseRecord>(model, CourseRecord);

			//CourseRecord.CourseID = model.CourseID;
			//CourseRecord.Title = model.Title;
			//CourseRecord.Credits = model.Credits;

			//if(model.Enrollments != null)
			//CourseRecord.Enrollments = model.Enrollments;
		}

		public void GetAll()
		{
			CourseRecord.CourseRecords = new ObservableCollection<Course>();
			_repository.GetAll().ForEach(data => CourseRecord.CourseRecords.Add(new Course()
			{
				CourseID = data.CourseID,
				Title = data.Title,
				Credits = data.Credits,
				//Enrollments = data.Enrollments,
			}));
		}
	}
}
