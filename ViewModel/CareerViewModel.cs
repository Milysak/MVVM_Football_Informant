using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Football_Informant.ViewModel
{
    using MVVM_Football_Informant.Model;
    using BaseClass;
    using DAL.Entities;

    class CareerViewModel : ViewModelBase
    {
        #region Private Fields
        private Model model = null;
        #endregion

        #region Constructors
        public CareerViewModel(Model model)
        {
            this.model = model;
        }
        #endregion

        #region Properties
        /*
        public bool LeagueComboboxIsEnable
        {
            get { return leagueComboboxIsEnable; }
            set
            {
                leagueComboboxIsEnable = value;
                onPropertyChanged(nameof(LeagueComboboxIsEnable));
            }
        }
        */
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
        /*
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
        */
        #endregion
    }
}
