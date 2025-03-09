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
    public class ShowAccomodationsViewModel : INotifyPropertyChanged
    {
        public string typee;
        public string name;
        public int numberOfGuests;

        public ICommand ShowByTypeCommand { get; set; }
        public ICommand ShowByNameCommand { get; set; }
        public ICommand ShowByNumOfGuestsCommand { get; set; }

        public ObservableCollection<AccomodationDTO> filteredAccomodations { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        AccomodationRepository accomodationRepository = new AccomodationRepository();

        public ShowAccomodationsViewModel()
        {
            ShowByTypeCommand = new DelegateCommand(ShowByType);
            ShowByNameCommand = new DelegateCommand(ShowByName);
            ShowByNumOfGuestsCommand = new DelegateCommand(ShowByNumOfGuests);
        }

        public ObservableCollection<AccomodationDTO> FilteredAccomodations
        {
            get { return filteredAccomodations; }
            set
            {
                filteredAccomodations = value;
                RaisePropertyChanged(nameof(filteredAccomodations));
            }
        }

        public string Typee
        {
            get { return typee; }
            set
            {
                typee = value;
                RaisePropertyChanged(nameof(Typee));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
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

        public void ShowByType()
        {
            FilteredAccomodations = new ObservableCollection<AccomodationDTO>(accomodationRepository.ShowByTypeDTO(Typee));
            return;
        }

        public void ShowByName()
        {
            FilteredAccomodations = new ObservableCollection<AccomodationDTO>(accomodationRepository.ShowByNameDTO(Name));
            return;
        }

        public void ShowByNumOfGuests()
        {
            FilteredAccomodations = new ObservableCollection<AccomodationDTO>(accomodationRepository.ShowByNumOfGuestsDTO(NumberOfGuests));
            return;
        }



        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
