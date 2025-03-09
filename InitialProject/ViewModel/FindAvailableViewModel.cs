using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
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
    public class FindAvailableViewModel : INotifyPropertyChanged
    {
        public DateTime start;
        public DateTime end;
        public int numberOfGuests;

        public ICommand FindAvailableCommand { get; set; }

        public ObservableCollection<AccomodationDTO> filteredAccomodations { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public FindAvailableViewModel()
        {
            FindAvailableCommand = new DelegateCommand(FindAvailable);
        }

        public ObservableCollection<AccomodationDTO> FilteredAccomodations
        {
            get { return filteredAccomodations; }
            set
            {
                filteredAccomodations = value;
                RaisePropertyChanged(nameof(FilteredAccomodations));
            }
        }

        public DateTime Start
        {
            get { return start; }
            set
            {
                start = value;
                RaisePropertyChanged(nameof(Start));
            }
        }

        public DateTime End
        {
            get { return end; }
            set
            {
                end = value;
                RaisePropertyChanged(nameof(End));
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

        public void FindAvailable()
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            FilteredAccomodations = new ObservableCollection<AccomodationDTO>(accomodationRepository.GetAvailableAccomodationsDTO(Start, End, NumberOfGuests));
            return;
        }




        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
