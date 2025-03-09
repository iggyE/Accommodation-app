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
    /// Interaction logic for ShowAccomodationsWindow.xaml
    /// </summary>
    public partial class ShowAccomodationsWindow : Window
    {
        public ShowAccomodationsWindow()
        {
            InitializeComponent();
            ShowAccomodationsViewModel viewModel = new ShowAccomodationsViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemComma)
            {
                if(DataContext is  ShowAccomodationsViewModel viewModel)
                {
                    viewModel.ShowByTypeCommand.Execute(null);
                }
            }
            if (e.Key == Key.OemPeriod)
            {
                if (DataContext is ShowAccomodationsViewModel viewModel)
                {
                    viewModel.ShowByNameCommand.Execute(null);
                }
            }
            if (e.Key == Key.OemQuestion)
            {
                if (DataContext is ShowAccomodationsViewModel viewModel)
                {
                    viewModel.ShowByNumOfGuestsCommand.Execute(null);
                }
            }
            if(e.Key == Key.X)
            {
                this.Close();
            }
        }

    }
}
