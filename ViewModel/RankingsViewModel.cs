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
    using MVVM_Football_Informant.DAL;
    using BaseClass;
    using Views;
    using DAL.Entities;
    using DAL.Repositories;

    class RankingsViewModel : ViewModelBase
    {
        #region Private Fields
        private Model model = null;

        private string typeOfRanking = null;
        private string targetOfRanking = null;

        private List<string> rankingComboboxContent = new List<string>();
        private List<string> typeComboboxContent = new List<string>();
        private List<string> typeToClubs = new List<string>();
        private List<string> typeToStadiums = new List<string>();
        private List<string> typeToLeagues = new List<string>();

        private bool typeComboboxIsEnable = false;
        private bool federationComboboxIsEnable = false;
        private bool leagueComboboxIsEnable = false;
        private bool clubComboboxIsEnable = false;

        private Visibility leaguesComboboxVisibility = Visibility.Hidden;

        private Federation actualFederation = null;
        private League actualLeague = null;

        private List<string> listRanking = null;

        private ObservableCollection<Federation> federations = null;
        private ObservableCollection<League> leagues = null;
        private ObservableCollection<Club> clubs = null;
        private ObservableCollection<Stadium> stadiums = null;
        #endregion

        #region Constructors
        public RankingsViewModel(Model model)
        {
            this.model = model;
            this.federations = model.Federations;
            this.leagues = model.Leagues;
            this.clubs = model.Clubs;
            this.stadiums = model.Stadiums;

            rankingComboboxContent.Add("Ligi");
            rankingComboboxContent.Add("Kluby");
            rankingComboboxContent.Add("Stadiony");

            typeToClubs.Add("Trofea");
            typeToClubs.Add("Wartość");
            typeToClubs.Add("Najstarszy");

            typeToLeagues.Add("Najlepsza");

            typeToStadiums.Add("Pojemność");
            typeToStadiums.Add("Najstarszy");
        }
        #endregion

        #region Properties
        public bool TypeComboboxIsEnable
        {
            get { return typeComboboxIsEnable; }
            set
            {
                typeComboboxIsEnable = value;
                onPropertyChanged(nameof(TypeComboboxIsEnable));
            }
        }

        public List<string> RankingComboboxContent
        {
            get { return rankingComboboxContent; }
            set
            {
                rankingComboboxContent = value;
                onPropertyChanged(nameof(RankingComboboxContent));
            }
        }
        
        public List<string> TypeComboboxContent
        {
            get { return typeComboboxContent; }
            set
            {
                typeComboboxContent = value;
                onPropertyChanged(nameof(TypeComboboxContent));
            }
        }

        public List<string> ListRanking
        {
            get { return listRanking; }
            set
            {
                listRanking = value;
                onPropertyChanged(nameof(ListRanking));
            }
        }

        public string TypeOfRanking
        {
            get { return typeOfRanking; }
            set
            {
                typeOfRanking = value;
                onPropertyChanged(nameof(TypeOfRanking));
            }
        }
        
        public string TargetOfRanking
        {
            get { return targetOfRanking; }
            set
            {
                targetOfRanking = value;
                onPropertyChanged(nameof(TargetOfRanking));
            }
        }

        public bool FederationComboboxIsEnable
        {
            get { return federationComboboxIsEnable; }
            set
            {
                federationComboboxIsEnable = value;
                onPropertyChanged(nameof(FederationComboboxIsEnable));
            }
        }

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

        public Visibility LeaguesComboboxVisibility
        {
            get { return leaguesComboboxVisibility; }
            set
            {
                leaguesComboboxVisibility = value;
                onPropertyChanged(nameof(LeaguesComboboxVisibility));
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

        private List<string> reflashRanking()
        {
            List<string> strings = new List<string>();

            if (TargetOfRanking != null && TypeOfRanking != null)
            {
                if (TargetOfRanking.Equals(rankingComboboxContent[0])) // Ligi
                {
                    strings = leaguesRanking();
                }
                else if (TargetOfRanking.Equals(rankingComboboxContent[1])) // Kluby
                {
                    strings = clubsRanking();
                }
                else if (TargetOfRanking.Equals(rankingComboboxContent[2])) // Stadiony
                {
                    strings = stadiumsRanking();
                }
            }

            return strings;
        }

        private List<string> leaguesRanking()
        {
            List<string> strings = new List<string>();

            return strings;
        }

        private List<string> clubsRanking()
        {
            List<string> strings = new List<string>();
            List<Club> clubs = new List<Club>();

            clubs = model.DownloadSortedClubsBy(TypeOfRanking);

            var i = 0;
            foreach (Club club in clubs)
            {
                if (i == 10)
                    break;
                if (ActualLeague != null)
                {
                    if (club.LeagueName.Equals(ActualLeague.Name))
                        strings.Add((i + 1) + ". " + club.Name);
                    i++;
                }
                else
                {
                    strings.Add((i + 1) + ". " + club.Name);
                    i++;
                }
            }
                
            return strings;
        }

        private List<string> stadiumsRanking()
        {
            List<string> strings = new List<string>();

            return strings;
        }
        #endregion

        #region ICommand
        private ICommand _loadFederations = null;
        public ICommand LoadFederations
        {
            get
            {
                if (_loadFederations == null)
                    _loadFederations = new RelayCommand(
                        arg => {
                            FederationComboboxIsEnable = true;

                            ActualFederation = null;
                            ActualLeague = null;

                            LeagueComboboxIsEnable = false;

                            ListRanking = null;

                            ListRanking = reflashRanking();
                        },
                        arg => true
                        );

                return _loadFederations;
            }
        }

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

                                ActualLeague = null;
                            }

                            ActualLeague = null;

                            LeagueComboboxIsEnable = true;
                            ClubComboboxIsEnable = false;

                            ListRanking = reflashRanking();
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
                                ListRanking = reflashRanking();
                            }

                            ClubComboboxIsEnable = true;
                        },
                        arg => true
                        );

                return _loadClubsFromLeague;
            }
        }
        
        private ICommand _loadTypesComboBox = null;
        public ICommand LoadTypesComboBox
        {
            get
            {
                if (_loadTypesComboBox == null)
                    _loadTypesComboBox = new RelayCommand(
                        arg => {
                                TypeComboboxIsEnable = true;

                                if (TargetOfRanking.Equals(RankingComboboxContent[0]))
                                {
                                    TypeComboboxContent = typeToLeagues;

                                    LeaguesComboboxVisibility = Visibility.Hidden;
                                }
                                else if (TargetOfRanking.Equals(RankingComboboxContent[1]))
                                {
                                    TypeComboboxContent = typeToClubs;

                                    LeaguesComboboxVisibility = Visibility.Visible;
                                }
                                else if (TargetOfRanking.Equals(RankingComboboxContent[2]))
                                {
                                    TypeComboboxContent = typeToStadiums;

                                    LeaguesComboboxVisibility = Visibility.Visible;
                                }
                        },
                        arg => true
                        );

                return _loadTypesComboBox;
            }
        }
        #endregion
    }
}
