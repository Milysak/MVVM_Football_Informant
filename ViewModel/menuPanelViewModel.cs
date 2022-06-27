using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVM_Football_Informant.ViewModel
{
    using MVVM_Football_Informant.Model;
    using BaseClass;

    class menuPanelViewModel : ViewModelBase
    {
        #region Składowe prywatne
        private Model model = null;
        private Visibility menuPanelVisibility = Visibility.Visible;
        private Visibility clubsPanelVisibility = Visibility.Hidden;
        private Visibility gamesPanelVisibility = Visibility.Hidden;
        private Visibility rankingsPanelVisibility = Visibility.Hidden;
        private Visibility careerPanelVisibility = Visibility.Hidden;
        #endregion

        #region Konstruktory
        public menuPanelViewModel(Model model)
        {
            this.model = model;
        }
        #endregion

        #region Properties
        public Visibility MenuPanelVisibility
        {
            get { return menuPanelVisibility; }
            set
            {
                menuPanelVisibility = value;
                onPropertyChanged(nameof(MenuPanelVisibility));
            }
        }

        public Visibility ClubsPanelVisibility
        {
            get { return clubsPanelVisibility; }
            set
            {
                clubsPanelVisibility = value;
                onPropertyChanged(nameof(ClubsPanelVisibility));
            }
        }
        
        public Visibility GamesPanelVisibility
        {
            get { return gamesPanelVisibility; }
            set
            {
                gamesPanelVisibility = value;
                onPropertyChanged(nameof(GamesPanelVisibility));
            }
        }

        public Visibility RankingsPanelVisibility
        {
            get { return rankingsPanelVisibility; }
            set
            {
                rankingsPanelVisibility = value;
                onPropertyChanged(nameof(RankingsPanelVisibility));
            }
        }

        public Visibility CareerPanelVisibility
        {
            get { return careerPanelVisibility; }
            set
            {
                careerPanelVisibility = value;
                onPropertyChanged(nameof(CareerPanelVisibility));
            }  
        }
        #endregion

        #region Methods
        #endregion

        #region ICommands
        private ICommand _showMenuPanel = null;
        public ICommand ShowMenuPanel
        {
            get
            {
                if (_showMenuPanel == null)
                    _showMenuPanel = new RelayCommand(
                        arg => {
                            MenuPanelVisibility = Visibility.Visible;
                            ClubsPanelVisibility = Visibility.Hidden;
                            GamesPanelVisibility = Visibility.Hidden;
                            RankingsPanelVisibility = Visibility.Hidden;
                            CareerPanelVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showMenuPanel;
            }
        }

        private ICommand _showClubsPanel = null;
        public ICommand ShowClubsPanel
        {
            get
            {
                if (_showClubsPanel == null)
                    _showClubsPanel = new RelayCommand(
                        arg => {
                            MenuPanelVisibility = Visibility.Hidden;
                            ClubsPanelVisibility = Visibility.Visible;
                            GamesPanelVisibility = Visibility.Hidden;
                            RankingsPanelVisibility = Visibility.Hidden;
                            CareerPanelVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showClubsPanel;
            }
        }

        private ICommand _showGamesPanel = null;
        public ICommand ShowGamesPanel
        {
            get
            {
                if (_showGamesPanel == null)
                    _showGamesPanel = new RelayCommand(
                        arg => {
                            MenuPanelVisibility = Visibility.Hidden;
                            ClubsPanelVisibility = Visibility.Hidden;
                            GamesPanelVisibility = Visibility.Visible;
                            RankingsPanelVisibility = Visibility.Hidden;
                            CareerPanelVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showGamesPanel;
            }
        }

        private ICommand _showRankingsPanel = null;
        public ICommand ShowRankingsPanel
        {
            get
            {
                if (_showRankingsPanel == null)
                    _showRankingsPanel = new RelayCommand(
                        arg => {
                            MenuPanelVisibility = Visibility.Hidden;
                            ClubsPanelVisibility = Visibility.Hidden;
                            GamesPanelVisibility = Visibility.Hidden;
                            RankingsPanelVisibility = Visibility.Visible;
                            CareerPanelVisibility = Visibility.Hidden;
                        },
                        arg => true
                        );

                return _showRankingsPanel;
            }
        }
        
        private ICommand _showCareerPanel = null;
        public ICommand ShowCareerPanel
        {
            get
            {
                if (_showCareerPanel == null)
                    _showCareerPanel = new RelayCommand(
                        arg => {
                            MenuPanelVisibility = Visibility.Hidden;
                            ClubsPanelVisibility = Visibility.Hidden;
                            GamesPanelVisibility = Visibility.Hidden;
                            RankingsPanelVisibility = Visibility.Hidden;
                            CareerPanelVisibility = Visibility.Visible;
                        },
                        arg => true
                        );

                return _showCareerPanel;
            }
        }

        private ICommand _applicationCloseCommand = null;
        public ICommand ApplicationCloseCommand
        {
            get
            {
                if (_applicationCloseCommand == null)
                    _applicationCloseCommand = new RelayCommand(
                        arg => {
                            App.Current.Shutdown();
                        },
                        arg => true
                        );

                return _applicationCloseCommand;
            }
        }
        #endregion
    }
}
