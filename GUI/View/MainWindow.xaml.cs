using GUI.ViewModel;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
