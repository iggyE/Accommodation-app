using InitialProject.Commands;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using InitialProject.DTO;
using System.Collections.ObjectModel;
using InitialProject.Repository;

namespace InitialProject.ViewModel
{
    public class ReservatingViewModel : INotifyPropertyChanged
    {
        private DateTime dateIn;
        private DateTime dateOut;
        private int numberOfGuests;

        private AccomodationDTO selectedAccomodation;

        public ICommand ReservatingCommand { get; set; }

        AccomodationRepository accomodationRepository = new AccomodationRepository();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<AccomodationDTO> Accomodations { get; set; }
        public ReservatingViewModel()
        {
            ReservatingCommand = new DelegateCommand(Reservating);

            Accomodations = accomodationRepository.GetAllWithoutLocationAccomodationDTO();
        }

        public AccomodationDTO SelectedAccomodation
        {
            get { return selectedAccomodation; }
            set
            {
                selectedAccomodation = value;
                RaisePropertyChanged(nameof(SelectedAccomodation));
            }
        }

        public int NumberOfGuests
        {
            get { return numberOfGuests; }
            set
            {
                numberOfGuests = value;
                RaisePropertyChanged(nameof(NumberOfGuests));

            }
        }

        public DateTime DateIn
        {
            get { return dateIn; }
            set
            {
                dateIn = value;
                RaisePropertyChanged(nameof(DateIn));
            }
        }

        public DateTime DateOut
        {
            get { return dateOut; }
            set
            {
                dateOut = value;
                RaisePropertyChanged(nameof(DateOut));
            }
        }

        public void Reservating()
        {
            AccomodationService accomodationService = new AccomodationService();
            AccomodationRepository accomodationRepository = new AccomodationRepository();

            if(SelectedAccomodation.MaxGuests >= NumberOfGuests)
            {
                accomodationService.MakeReservation(SelectedAccomodation.AccId, NumberOfGuests, DateIn, DateOut);
                MessageBox.Show("Succesfully reserved accomodation!");
                return;
            }
            else
            {
                MessageBox.Show("Maximum guests reached! Cant Reservate.");
                return;
            }

        }



        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
