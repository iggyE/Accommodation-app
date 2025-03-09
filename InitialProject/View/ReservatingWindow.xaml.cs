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
    /// Interaction logic for ReservatingWindow.xaml
    /// </summary>
    public partial class ReservatingWindow : Window
    {
        public ReservatingWindow()
        {
            InitializeComponent();
            ReservatingViewModel viewModel = new ReservatingViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R)
            {
                if (DataContext is ReservatingViewModel viewModel)
                {
                    viewModel.ReservatingCommand.Execute(null);
                }
            }

            if (e.Key == Key.T)
            {
                TutorialWindow tutorialWindow = new TutorialWindow();
                tutorialWindow.Show();
            }

            if (e.Key == Key.X)
            {
                this.Close();
            }
        }
    }
}
