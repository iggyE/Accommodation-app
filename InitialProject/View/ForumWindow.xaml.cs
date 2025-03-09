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
    /// Interaction logic for ForumWindow.xaml
    /// </summary>
    public partial class ForumWindow : Window
    {
        public ForumWindow()
        {
            InitializeComponent();
            ForumViewModel viewModel = new ForumViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemComma)
            {
                if (DataContext is ForumViewModel viewModel)
                {
                    viewModel.AddCommentCommand.Execute(null); 
                }
            }
            if (e.Key == Key.OemPeriod)
            {
                if (DataContext is ForumViewModel viewModel)
                {
                    viewModel.CloseForumCommand.Execute(null);
                }
            }
            if (e.Key == Key.OemQuestion)
            {
                if (DataContext is ForumViewModel viewModel)
                {
                    viewModel.OpenForumCommand.Execute(null);
                }
            }

            if (e.Key == Key.X)
            {
                this.Close();
            }
        }

    }
}
