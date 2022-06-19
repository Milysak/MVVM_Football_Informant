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

    class GameViewModel
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
        public GameViewModel(Model model)
        {
            this.model = model;
            this.federations = model.Federations;
            this.leagues = model.Leagues;
            this.clubs = model.Clubs;
            this.stadiums = model.Stadiums;
            this.workers = model.Workers;
        }
        #endregion
    }
}
