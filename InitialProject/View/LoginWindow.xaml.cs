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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            GuestViewModel viewModel = new GuestViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L)
            {
                GuestWindow guestWindow = new GuestWindow();
                guestWindow.Show();
            }
            if (e.Key == Key.X)
            {
                this.Close();
            }
            if (e.Key == Key.L)
            {
                this.Close();
            }
        }
    }
}
