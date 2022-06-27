using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Football_Informant.ViewModel
{
    using MVVM_Football_Informant.Model;
    using BaseClass;
    using DAL.Entities;
    using CareerViewModelElements;

    class CareerViewModel : ViewModelBase
    {
        public CareerPlaySimulationViewModel CareerPlaySimulationVM { set; get; }
        public CareerYourProfileViewModel CareerYourProfileVM { set; get; }
        public CareerClubViewModel CareerClubVM { set; get; }
        public CareerStandingsViewModel CareerStandingsVM { set; get; }
        public CareerMarketPlaceViewModel CareerMarketPlaceVM { set; get; }

        #region Private Fields
        private Model model = null;

        private Visibility careerClubVisibility = Visibility.Hidden;
        private Visibility careerMarketPlaceVisibility = Visibility.Hidden;
        private Visibility careerPlaySimulationVisibility = Visibility.Hidden;
        private Visibility careerStandingsVisibility = Visibility.Hidden;
        private Visibility careerYourProfileVisibility = Visibility.Hidden;
        #endregion

        #region Constructors
        public CareerViewModel(Model model)
        {
            this.model = model;

            CareerPlaySimulationVM = new CareerPlaySimulationViewModel(model);
            CareerYourProfileVM = new CareerYourProfileViewModel(model);
            CareerClubVM = new CareerClubViewModel(model);
            CareerStandingsVM = new CareerStandingsViewModel(model);
            CareerMarketPlaceVM = new CareerMarketPlaceViewModel(model);
        }
        #endregion

        #region Properties
        public Visibility CareerClubVisibility
        {
            get { return careerClubVisibility; }
            set
            {
                careerClubVisibility = value;
                onPropertyChanged(nameof(CareerClubVisibility));
            }
        }

        public Visibility CareerMarketPlaceVisibility
        {
            get { return careerMarketPlaceVisibility; }
            set
            {
                careerMarketPlaceVisibility = value;
                onPropertyChanged(nameof(CareerMarketPlaceVisibility));
            }
        }

        public Visibility CareerPlaySimulationVisibility
        {
            get { return careerPlaySimulationVisibility; }
            set
            {
                careerPlaySimulationVisibility = value;
                onPropertyChanged(nameof(CareerPlaySimulationVisibility));
            }
        }

        public Visibility CareerStandingsVisibility
        {
            get { return careerStandingsVisibility; }
            set
            {
                careerStandingsVisibility = value;
                onPropertyChanged(nameof(CareerStandingsVisibility));
            }
        }

        public Visibility CareerYourProfileVisibility
        {
            get { return careerYourProfileVisibility; }
            set
            {
                careerYourProfileVisibility = value;
                onPropertyChanged(nameof(CareerYourProfileVisibility));
            }
        }
        #endregion

        #region Methods
        /*
        private ObservableCollection<League> loadLeaguesFromFederation()
        {
            var list = new ObservableCollection<League>();

            foreach (var league in leagues)
            {
                //MessageBox.Show(league.FederationName + " " + this.actualFederation.Name + " ");
                if (league.FederationName.Equals(this.actualFederation.Name))
                    list.Add(league);
            }

            return list;
        }
        */
        #endregion

        #region ICommand
        private ICommand _showCareerClubPanel = null;
        public ICommand ShowCareerClubPanel
        {
            get
            {
                if (_showCareerClubPanel == null)
                    _showCareerClubPanel = new RelayCommand(
                        arg => {
                            CareerClubVisibility = Visibility.Visible;
                            CareerMarketPlaceVisibility = Visibility.Hidden;
                            CareerPlaySimulationVisibility = Visibility.Hidden;
                            CareerStandingsVisibility = Visibility.Hidden;
                            CareerYourProfileVisibility = Visibility.Hidden;
        },
                        arg => true
                        );

                return _showCareerClubPanel;
            }
        }

        private ICommand _showCareerMarketPlacePanel = null;
        public ICommand ShowCareerMarketPlacePanel
        {
            get
            {
                if (_showCareerMarketPlacePanel == null)
                    _showCareerMarketPlacePanel = new RelayCommand(
                        arg => {
                            CareerClubVisibility = Visibility.Hidden;
                            CareerMarketPlaceVisibility = Visibility.Visible;
                            CareerPlaySimulationVisibility = Visibility.Hidden;
                            CareerStandingsVisibility = Visibility.Hidden;
                            CareerYourProfileVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showCareerMarketPlacePanel;
            }
        }

        private ICommand _showCareerPlaySimulationPanel = null;
        public ICommand ShowCareerPlaySimulationPanel
        {
            get
            {
                if (_showCareerPlaySimulationPanel == null)
                    _showCareerPlaySimulationPanel = new RelayCommand(
                        arg => {
                            CareerClubVisibility = Visibility.Hidden;
                            CareerMarketPlaceVisibility = Visibility.Hidden;
                            CareerPlaySimulationVisibility = Visibility.Visible;
                            CareerStandingsVisibility = Visibility.Hidden;
                            CareerYourProfileVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showCareerPlaySimulationPanel;
            }
        }

        private ICommand _showCareerStandingsPanel = null;
        public ICommand ShowCareerStandingsPanel
        {
            get
            {
                if (_showCareerStandingsPanel == null)
                    _showCareerStandingsPanel = new RelayCommand(
                        arg => {
                            CareerClubVisibility = Visibility.Hidden;
                            CareerMarketPlaceVisibility = Visibility.Hidden;
                            CareerPlaySimulationVisibility = Visibility.Hidden;
                            CareerStandingsVisibility = Visibility.Visible;
                            CareerYourProfileVisibility = Visibility.Hidden;
                        }, 
                        arg => true
                        );

                return _showCareerStandingsPanel;
            }
        }

        private ICommand _showCareerYourProfilePanel = null;
        public ICommand ShowCareerYourProfilePanel
        {
            get
            {
                if (_showCareerYourProfilePanel == null)
                    _showCareerYourProfilePanel = new RelayCommand(
                        arg => {
                            CareerClubVisibility = Visibility.Hidden;
                            CareerMarketPlaceVisibility = Visibility.Hidden;
                            CareerPlaySimulationVisibility = Visibility.Hidden;
                            CareerStandingsVisibility = Visibility.Hidden;
                            CareerYourProfileVisibility = Visibility.Visible;
                        },
                        arg => true
                        );

                return _showCareerYourProfilePanel;
            }
        }
        #endregion
    }
}
