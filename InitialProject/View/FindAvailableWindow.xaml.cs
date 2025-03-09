using InitialProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for FindAvailableWindow.xaml
    /// </summary>
    public partial class FindAvailableWindow : Window
    {
        public FindAvailableWindow()
        {
            InitializeComponent();
            FindAvailableViewModel viewModel = new FindAvailableViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPeriod)
            {
                if(DataContext is  FindAvailableViewModel viewModel)
                {
                    viewModel.FindAvailableCommand.Execute(null);
                }
            }
            
            if (e.Key == Key.X)
            {
                this.Close();
            }
        }
    }
}
