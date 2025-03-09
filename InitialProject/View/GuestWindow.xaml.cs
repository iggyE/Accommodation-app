using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Service;
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
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {

        public GuestWindow()
        {
            InitializeComponent();
            GuestViewModel viewModel = new GuestViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F)
            {
                ForumWindow forumWindow = new ForumWindow();
                forumWindow.Show();
            }
            if (e.Key == Key.S)
            {
                ShowAccomodationsWindow showAccomodationsWindow = new ShowAccomodationsWindow();
                showAccomodationsWindow.Show();
            }
            if (e.Key == Key.H)
            {
                GuestWindow guestWindow = new GuestWindow();
                guestWindow.Show();
            }
            if (e.Key == Key.A)
            {
                AccomodationSpecialWindow accomodationSpecialWindow = new AccomodationSpecialWindow();
                accomodationSpecialWindow.Show();
            }
            if (e.Key == Key.P)
            {
                PerformanceWindow performanceWindow = new PerformanceWindow();
                performanceWindow.Show();
            }
            if (e.Key == Key.R)
            {
                ReservatingWindow reservatingWindow = new ReservatingWindow();
                reservatingWindow.Show();
            }
            if (e.Key == Key.X)
            {
                this.Close();
            }
            if (e.Key == Key.L)
            {
                LoginWindow lol = new LoginWindow();
                lol.Show();
            }

        }

    }
}
