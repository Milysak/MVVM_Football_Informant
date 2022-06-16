using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Football_Informant.Model
{
    using DAL.Entities;
    using DAL.Repositories;
    using System.Collections.ObjectModel;

    class Model
    {
        // Stan bazy
        public ObservableCollection<Club> Clubs { get; set; } = new ObservableCollection<Club>();
        public ObservableCollection<Federation> Federations { get; set; } = new ObservableCollection<Federation>();
        public ObservableCollection<League> Leagues { get; set; } = new ObservableCollection<League>();
        public ObservableCollection<Stadium> Stadiums { get; set; } = new ObservableCollection<Stadium>();
        public ObservableCollection<Worker> Workers { get; set; } = new ObservableCollection<Worker>();

        // Stan Ranking
        public ObservableCollection<Club> ClubsSortedByTrophies { get; set; } = new ObservableCollection<Club>();
        public ObservableCollection<Club> ClubsSortedByTeamvalue { get; set; } = new ObservableCollection<Club>();
        public ObservableCollection<Club> ClubsSortedByAge { get; set; } = new ObservableCollection<Club>();

        public ObservableCollection<League> LeaguesSortedByPositionInRanking { get; set; } = new ObservableCollection<League>();

        public ObservableCollection<Stadium> StadiumsSortedByCapacity { get; set; } = new ObservableCollection<Stadium>();
        public ObservableCollection<Stadium> StadiumsSortedByAge { get; set; } = new ObservableCollection<Stadium>();

        public Model()
        {
            // Pobranie danych z bazy do kolekcji
            var clubs = ClubsRepository.DownloadAllClubs();
            foreach (var c in clubs)
                Clubs.Add(c);

            var federations = FederationsRepository.DownloadAllFederations();
            foreach (var f in federations)
                Federations.Add(f);

            var leagues = LeaguesRepository.DownloadAllLeagues();
            foreach (var l in leagues)
                Leagues.Add(l);

            var stadiums = StadiumsRepository.DownloadAllStadiums();
            foreach (var s in stadiums)
                Stadiums.Add(s);

            var workers = WorkersRepository.DownloadAllWorkers();
            foreach (var w in workers)
                Workers.Add(w);
        }

        public List<Club> DownloadSortedClubsBy(string rankingType)
        {
            return ClubsRepository.DownloadSortedClubsBy(rankingType);
        }
    }
}
