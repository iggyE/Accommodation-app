using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace InitialProject.ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        AccomodationRepository accomodationRepository = new AccomodationRepository();

        //HOME WINDOWI
        public ICommand HomeCommand { get; set; }
        public ICommand ShowAccomodationCommand { get; set; }
        public ICommand ReservatingCommand { get; set; }
        public ICommand PerformanceCommand { get; set; }
        public ICommand ForumCommand { get; set; }
        public ICommand AccomodationSpecialCommand { get; set; }
        public ICommand TutorialCommand { get; set; }

        private string username;
        private string password;
        public ICommand LoginCommand { get; set; }


        // PRAVE FUNKCIJE
        public ICommand RateAccomodationCommand { get; set; }
        public ICommand ReccommendationForRenovationCommand { get; set; }
        public ICommand RatingForYouCommand { get; set; }
        public ICommand FindAvailableCommand { get; set; }

        public ObservableCollection<AccomodationDTO> Accomodations { get; set; }

        public GuestViewModel()
        {
            ShowAccomodationCommand = new DelegateCommand(ShowAccomodations);
            ReservatingCommand = new DelegateCommand(Reservating);
            HomeCommand = new DelegateCommand(HomeBinding);
            ForumCommand = new DelegateCommand(Forum);
            AccomodationSpecialCommand = new DelegateCommand(AccomodationSpecial);
            TutorialCommand = new DelegateCommand(TutorialOpenWindow);
            FindAvailableCommand = new DelegateCommand(FindAvailable);
            PerformanceCommand = new DelegateCommand(Performance);
            LoginCommand = new DelegateCommand(Login);

            Accomodations = accomodationRepository.GetAllAccomodationsDTO();
        }

        public void Login()
        {
            if(username != null && password != null)
            {
                LoginCommand.Execute(null);
            }
        }


        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }


        private void TutorialOpenWindow()
        {
            var tutorialWindow = new TutorialWindow();
            tutorialWindow.Show();
        }

        private void Reservating()
        {
            var reservatingWindow = new ReservatingWindow();
            reservatingWindow.Show();
        }

        private void Performance()
        {
            var performanceWindow = new PerformanceWindow();
            performanceWindow.Show();
        }

        private void FindAvailable()
        {
            var findAvailableWindow = new FindAvailableWindow();
            findAvailableWindow.Show();
        }

        private void ShowAccomodations()
        {
            var showAccomodationWindow = new ShowAccomodationsWindow();
            showAccomodationWindow.ShowDialog();
        }

        private void AccomodationSpecial()
        {
            var accomodationSpecialWindow = new AccomodationSpecialWindow();
            accomodationSpecialWindow.ShowDialog();
        }

        private void Forum()
        {
            var forumWindow = new ForumWindow();
            forumWindow.ShowDialog();
        }


        private void HomeBinding()
        {
            var guestWindow = new GuestWindow();
            guestWindow.Show();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
}
