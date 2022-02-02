using EntityFramework_Test.Data;
using System.Windows;

namespace WpfCoreEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SchoolContext dataContext ;

        public MainWindow(SchoolContext dataContext)
        {
            InitializeComponent();

            this.dataContext = dataContext;
        }
    }
}
