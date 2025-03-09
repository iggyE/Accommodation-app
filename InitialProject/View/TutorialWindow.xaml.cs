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
    /// Interaction logic for TutorialWindow.xaml
    /// </summary>
    public partial class TutorialWindow : Window
    {
        public TutorialWindow()
        {
            InitializeComponent();
            TutorialViewModel viewModel = new TutorialViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.X)
            {
                this.Close();
            }

            if (e.Key == Key.M)
            {
                mediaElement.IsMuted = !mediaElement.IsMuted;
            }
            if (e.Key == Key.Left)
            {
                mediaElement.Position -= TimeSpan.FromSeconds(5);
            }
            else if (e.Key == Key.Right)
            {
                mediaElement.Position += TimeSpan.FromSeconds(5);
            }
            if(e.Key == Key.Space)
            {
                mediaElement.Pause();
            }

        }

        private void TutorialWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string videoPath = "C:\\Users\\Lenovo\\Desktop\\SIMS Igor\\InitialProject\\InitialProject\\Videos\\RezervacijaSmestajaOfficial.mp4"; 
            mediaElement.Source = new Uri(videoPath, UriKind.Relative);
            mediaElement.Play();
        }
    }
}
