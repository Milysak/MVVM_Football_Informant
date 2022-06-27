using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Football_Informant.ViewModel
{
    using MVVM_Football_Informant.Model;
    using BaseClass;
    using MVVM_Football_Informant.DAL;
    using System.Windows;

    class MainViewModel
    {
        //stworzenie instancji modelu
        private Model model = new Model();

        public menuPanelViewModel menuPanelVM { set; get; }
        public ClubsViewModel ClubsVM { set; get; }
        public RankingsViewModel RankingsVM { set; get; }
        public GameViewModel GameVM { set; get; }
        public CareerViewModel CareerVM { set; get; }

        public MainViewModel()
        {
            /* 
            Stworzenie viewmodeli pomocniczych - dla każdej karty
            przekazanie referencji do instancji modelu tak
            aby wszystkie obiekty modeli widoków pracowały na tym samym modelu...
            */
            menuPanelVM = new menuPanelViewModel(model);
            ClubsVM = new ClubsViewModel(model);
            RankingsVM = new RankingsViewModel(model);
            GameVM = new GameViewModel(model);
            CareerVM = new CareerViewModel(model);
        }
    }
}