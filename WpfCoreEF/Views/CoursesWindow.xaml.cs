using System.Windows;
using WpfCoreEF.ViewModel;

namespace WpfCoreEF.Views
{
    /// <summary>
    /// Interaktionslogik für Courses.xaml
    /// </summary>
    public partial class CoursesWindow : Window
    {
        public CoursesWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new CourseViewModel();
            DataContext = context;
        }
    }
}
