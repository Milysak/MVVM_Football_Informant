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
    using CareerViewModelElements;

    class CareerMainViewModel
    {
        private Model model = new Model();

        public CareerPlaySimulationViewModel CareerPlaySimulationVM { set; get; }
        public CareerYourProfileViewModel CareerYourProfileVM { set; get; }
        public CareerClubViewModel CareerClubVM { set; get; }
        public CareerStandingsViewModel CareerStandingsVM { set; get; }
        public CareerMarketPlaceViewModel CareerMarketPlaceVM { set; get; }

        public CareerMainViewModel()
        {
            CareerPlaySimulationVM = new CareerPlaySimulationViewModel(model);
            CareerYourProfileVM = new CareerYourProfileViewModel(model);
            CareerClubVM = new CareerClubViewModel(model);
            CareerStandingsVM = new CareerStandingsViewModel(model);
            CareerMarketPlaceVM = new CareerMarketPlaceViewModel(model);
        }
    }
}
