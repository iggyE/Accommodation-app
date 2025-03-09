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
    /// Interaction logic for AccomodationSpecialWindow.xaml
    /// </summary>
    public partial class AccomodationSpecialWindow : Window
    {
        public AccomodationSpecialWindow()
        {
            InitializeComponent();
            AccomodationSpecialViewModel viewModel = new AccomodationSpecialViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1)
            {
                FindAvailableWindow findAvailableWindow = new FindAvailableWindow();
                findAvailableWindow.Show();
                this.Close();
            }
            if (e.Key == Key.C)
            {
                if(DataContext is  AccomodationSpecialViewModel viewModel)
                {
                    viewModel.CancelReservationCommand.Execute(null);
                }
            }
            if (e.Key == Key.R)
            {
                ReportWindow reportWindow = new ReportWindow();
                reportWindow.Show();
            }
            if (e.Key == Key.X)
            {
                this.Close();
            }
        }

    }
}
