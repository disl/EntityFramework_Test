using System.Windows;
using WpfCoreEF.ViewModel;

namespace WpfCoreEF.Views
{
    /// <summary>
    /// Interaktionslogik für Courses.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new StudentViewModel();
            DataContext = context;
        }
    }
}
