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

    class RankingsViewModel : ViewModelBase
    {
        #region Private Fields
        private Model model = null;

        private string typeOfRanking = null;
        private string targetOfRanking = null;
        private string whereType = null;

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
        private Visibility federationComboboxVisibility = Visibility.Hidden;

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
            typeToClubs.Add("Rok utworzenia");

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
                if (value != null)
                {
                    if (value.Equals("Trofea"))
                        typeOfRanking = "trophiesNumber";
                    else if (value.Equals("Wartość"))
                        typeOfRanking = "teamValue";
                    else if (value.Equals("Rok utworzenia"))
                        typeOfRanking = "formYear";
                    else if (value.Equals("Najlepsza"))
                        typeOfRanking = "rankingPosition";
                    else if (value.Equals("Pojemność"))
                        typeOfRanking = "capacity";
                    else if (value.Equals("Najstarszy"))
                        typeOfRanking = "openDate";
                }
                else typeOfRanking = null;

                onPropertyChanged(nameof(TypeOfRanking));
            }
        }
        
        public string TargetOfRanking
        {
            get { return targetOfRanking; }
            set
            {
                //MessageBox.Show(value);
                if (value != null)
                {
                    if (value.Equals(rankingComboboxContent[0]))
                        targetOfRanking = "leagues";
                    else if (value.Equals(rankingComboboxContent[1]))
                        targetOfRanking = "clubs";
                    else if (value.Equals(rankingComboboxContent[2]))
                        targetOfRanking = "stadiums";
                }
                else targetOfRanking = null;

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
        
        public Visibility FederationComboboxVisibility
        {
            get { return federationComboboxVisibility; }
            set
            {
                federationComboboxVisibility = value;
                onPropertyChanged(nameof(FederationComboboxVisibility));
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

        private List<string> rankingElements()
        {
            var rankingElements = new List<string>();
            var elem = new List<dynamic>();

            if (TargetOfRanking != null && TypeOfRanking != null)
                elem = model.DownloadSortedRanking(TargetOfRanking, TypeOfRanking, whereType);
            else return null;

            if (elem.Count > 0)
            {
                if (elem[0].GetType().Equals(typeof(League)))
                {
                    var list = new List<League>();
                    foreach (var league in elem)
                        list.Add(league);

                    var i = 0;
                    foreach (var league in list)
                    {
                        i++;
                        rankingElements.Add(i + ". " + league.Name + " [" + league.PositionInRanking + "]");
                    }
                }
                else if (elem[0].GetType().Equals(typeof(Club)))
                {
                    var list = new List<Club>();
                    foreach (var club in elem)
                        list.Add(club);

                    var i = 0;
                    foreach (var club in list)
                    {
                        string data = "---";

                        if (TypeOfRanking.Equals("trophiesNumber"))
                            data = club.NumberOfTrophies.ToString();
                        else if (TypeOfRanking.Equals("teamValue"))
                            data = club.ValueOfTeam.ToString() + " mln €";
                        else if (TypeOfRanking.Equals("formYear"))
                            data = club.YearOfForm.ToString() + "r.";

                            i++;
                        rankingElements.Add(i + ". " + club.Name + " [" + data + "]");
                    }
                }
                else if (elem[0].GetType().Equals(typeof(Stadium)))
                {
                    var list = new List<Stadium>();
                    foreach (var stadium in elem)
                        list.Add(stadium);

                    var i = 0;
                    foreach (var stadium in list)
                    {
                        string data = "---";

                        if (TypeOfRanking.Equals("capacity"))
                            data = stadium.Capacity.ToString();
                        else if (TypeOfRanking.Equals("openDate"))
                            data = stadium.OpenYear.ToString() + "r.";

                        i++;
                        rankingElements.Add(i + ". " + stadium.Name + " [" + data + "]");
                    }
                }
            }

            return rankingElements;
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

                            if (TargetOfRanking != null)
                            {
                                ListRanking = rankingElements();
                            }
                            else ListRanking = null;

                            if (TargetOfRanking.Equals("leagues"))
                            {
                                ActualFederation = null;
                                ActualLeague = null;
                            }
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

                            LeagueComboboxIsEnable = true;

                            ActualLeague = null;
                            whereType = null;

                            if (ActualFederation != null && !TargetOfRanking.Equals("stadiums"))
                            {
                                Leagues = loadLeaguesFromFederation();

                                whereType = ActualFederation.Name;

                                ListRanking = rankingElements();
                            }
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

                            ClubComboboxIsEnable = true;

                            whereType = null;

                            if (ActualLeague != null)
                            {
                                whereType = ActualLeague.Name;
                                ListRanking = rankingElements();
                            }
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
                            //MessageBox.Show(TypeOfRanking);
                            TypeComboboxIsEnable = true;

                            ListRanking = null;
                            TypeOfRanking = null;
                            ActualFederation = null;
                            ActualLeague = null;

                            FederationComboboxIsEnable = false;
                            LeagueComboboxIsEnable = false;

                            if (TargetOfRanking.Equals("leagues"))
                            {
                                TypeComboboxContent = typeToLeagues;

                                FederationComboboxVisibility = Visibility.Visible;

                                LeaguesComboboxVisibility = Visibility.Hidden;
                            }
                            else if (TargetOfRanking.Equals("clubs"))
                            {
                                TypeComboboxContent = typeToClubs;

                                FederationComboboxVisibility = Visibility.Visible;

                                LeaguesComboboxVisibility = Visibility.Visible;
                            }
                            else if (TargetOfRanking.Equals("stadiums"))
                            {
                                TypeComboboxContent = typeToStadiums;

                                FederationComboboxVisibility = Visibility.Hidden;

                                LeaguesComboboxVisibility = Visibility.Hidden;
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
