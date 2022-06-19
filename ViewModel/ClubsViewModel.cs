using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace MVVM_Football_Informant.ViewModel
{
    using MVVM_Football_Informant.Model;
    using BaseClass;
    using DAL.Entities;

    class ClubsViewModel : ViewModelBase
    {
        #region Private Fields
        private Model model = null;

        private bool leagueComboboxIsEnable = false;
        private bool clubComboboxIsEnable = false;

        private Visibility clubDataGridVisibility = Visibility.Hidden;

        private Federation actualFederation = null;
        private League actualLeague = null;
        private Club actualClub = null;
        private Stadium actualStadium = null;
        private ObservableCollection<Worker> actualWorkers = null;

        private ObservableCollection<Federation> federations = null;
        private ObservableCollection<League> leagues = null;
        private ObservableCollection<Club> clubs = null;
        private ObservableCollection<Stadium> stadiums = null;
        private ObservableCollection<Worker> workers = null;
        #endregion

        #region Constructors
        public ClubsViewModel(Model model)
        {
            this.model = model;
            this.federations = model.Federations;
            this.leagues = model.Leagues;
            this.clubs = model.Clubs;
            this.stadiums = model.Stadiums;
            this.workers = model.Workers;
        }
        #endregion

        #region Properties
        public bool LeagueComboboxIsEnable
        {
            get { return leagueComboboxIsEnable; }
            set
            {
                leagueComboboxIsEnable = value;
                onPropertyChanged(nameof(LeagueComboboxIsEnable));
            }
        }

        public bool ClubComboboxIsEnable
        {
            get { return clubComboboxIsEnable; }
            set
            {
                clubComboboxIsEnable = value;
                onPropertyChanged(nameof(ClubComboboxIsEnable));
            }
        }

        public Visibility ClubDataGridVisibility
        {
            get { return clubDataGridVisibility; }
            set
            {
                clubDataGridVisibility = value;
                onPropertyChanged(nameof(ClubDataGridVisibility));
            }
        }

        public Federation ActualFederation 
        {
            get { return actualFederation; }
            set
            {
                actualFederation = value;
                onPropertyChanged(nameof(ActualFederation));
            }
        }

        public League ActualLeague
        {
            get { return actualLeague; }
            set
            {
                actualLeague = value;
                onPropertyChanged(nameof(ActualLeague));
            }
        }

        public Club ActualClub
        {
            get { return actualClub; }
            set
            {
                actualClub = value;
                onPropertyChanged(nameof(ActualClub));
            }
        }

        public Stadium ActualStadium
        {
            get { return actualStadium; }
            set
            {
                actualStadium = value;
                onPropertyChanged(nameof(ActualStadium));
            }
        }

        public ObservableCollection<Worker> ActualWorkers
        {
            get { return actualWorkers; }
            set
            {
                actualWorkers = value;
                onPropertyChanged(nameof(ActualWorkers));
            }
        }

        public ObservableCollection<Federation> Federations
        {
            get { return federations; }
            set
            {
                federations = value;
                onPropertyChanged(nameof(Federations));
            }
        }

        public ObservableCollection<League> Leagues
        {
            get { return leagues; }
            set
            {
                leagues = value;
                onPropertyChanged(nameof(Leagues));
            }
        }

        public ObservableCollection<Club> Clubs
        {
            get { return clubs; }
            set
            {
                clubs = value;
                onPropertyChanged(nameof(Clubs));
            }
        }

        public ObservableCollection<Stadium> Stadiums
        {
            get { return stadiums; }
            set
            {
                stadiums = value;
                onPropertyChanged(nameof(Stadiums));
            }
        }

        public ObservableCollection<Worker> Workers
        {
            get { return workers; }
            set
            {
                workers = value;
                onPropertyChanged(nameof(Workers));
            }
        }
        #endregion

        #region Methods
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

        private ObservableCollection<Club> loadClubsFromLeague()
        {
            var list = new ObservableCollection<Club>();

            foreach (var club in clubs)
                if (club.LeagueName.Equals(this.actualLeague.Name))
                    list.Add(club);

            return list;
        }

        private Stadium loadStadiumForClub()
        {
            foreach (var stadium in stadiums)
                if (stadium.Name.Equals(this.actualClub.StadiumName))
                    return stadium;
            return null;
        }

        private ObservableCollection<Worker> loadWorkersForClub()
        {
            var list = new ObservableCollection<Worker>();

            foreach (var worker in workers)
                if (worker.ClubName.Equals(this.actualClub.Name))
                    list.Add(worker);

            return list;
        }
        #endregion

        #region ICommand
        private ICommand _loadLeaguesFromFederation = null;
        public ICommand LoadLeaguesFromFederation
        {
            get
            {
                if (_loadLeaguesFromFederation == null)
                    _loadLeaguesFromFederation = new RelayCommand(
                        arg => {
                            Leagues = model.Leagues;
                            if (ActualFederation != null)
                            {
                                Leagues = loadLeaguesFromFederation();
                            }

                            ActualLeague = null;
                            ActualClub = null;
                            ActualStadium = null;
                            ActualWorkers = null;

                            LeagueComboboxIsEnable = true;
                            ClubComboboxIsEnable = false;
                            ClubDataGridVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _loadLeaguesFromFederation;
            }
        }

        private ICommand _loadClubsFromLeague = null;
        public ICommand LoadClubsFromLeague
        {
            get
            {
                if (_loadClubsFromLeague == null)
                    _loadClubsFromLeague = new RelayCommand(
                        arg => {
                            Clubs = model.Clubs;
                            if (ActualLeague != null)
                            {
                                Clubs = loadClubsFromLeague();
                            }

                            ActualClub = null;

                            ClubComboboxIsEnable = true;
                            ClubDataGridVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _loadClubsFromLeague;
            }
        }

        private ICommand _showClubDataGrid = null;
        public ICommand ShowClubDataGrid
        {
            get
            {
                if (_showClubDataGrid == null)
                    _showClubDataGrid = new RelayCommand(
                        arg => {
                            Stadiums = model.Stadiums;
                            Workers = model.Workers;

                            ClubDataGridVisibility = Visibility.Visible;
                            if (this.ActualClub != null)
                            {
                                this.ActualStadium = loadStadiumForClub();
                                this.ActualWorkers = loadWorkersForClub();
                            }
                        },
                        arg => true
                        );

                return _showClubDataGrid;
            }
        }
        #endregion
    }
}
