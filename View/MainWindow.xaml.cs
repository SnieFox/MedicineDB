using MedicineDB.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MedicineDB
{
    public partial class MainWindow : Window
    {
        public static DataGrid AllEmployeesView;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
            AllEmployeesView = employeesGrid;
        }
    }
}
