using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class AccomodationSpecialViewModel : INotifyPropertyChanged
    {
        AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();

        private AccomodationReservationDTO selectedReservation;

        
        public ICommand CancelReservationCommand { get; set; }
        public ICommand FindAvailableCommand { get; set; }
        public ICommand ShowReservationsCommand { get; set; }

        public ObservableCollection<AccomodationReservationDTO> Reservations { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;


        public AccomodationSpecialViewModel()
        {
            CancelReservationCommand = new DelegateCommand(CancelReservationn);
            FindAvailableCommand = new DelegateCommand(FindAvailablee);

            Reservations = accomodationReservationRepository.GetAllReservationsDTO();
        }

        private void FindAvailablee()
        {
            var findAvailableWindow = new FindAvailableWindow();
            findAvailableWindow.Show();
        }


        public AccomodationReservationDTO SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                selectedReservation = value;
                RaisePropertyChanged(nameof(SelectedReservation));
            }
        }

        public void CancelReservationn()
        {
            int accId = SelectedReservation.AccomodationId;

            AccomodationService accomodationService = new AccomodationService();
            accomodationService.CancelReservation(accId);                              // ID TREBA OD SELEKTOVANOG
            MessageBox.Show("Succesfully removed accomodation reservation!");
            return;
        }


        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
