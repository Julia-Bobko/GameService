using GameService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StatisticsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StatisticsService.svc or StatisticsService.svc.cs at the Solution Explorer and start debugging.
    [DataContract]
    public class StatisticsService : IStatisticsService
    {
        StatisticsRepository statisticsRepository = null;
        public StatisticsService()
        {
            statisticsRepository = new StatisticsRepository();
        }

        public bool CreateStatistics(string titleGame, string userName, string country, string count)
        {
            var result = statisticsRepository.CreateStatistics(titleGame, userName, country, count);
            return result;
        }

        public bool UpdateStatistics(string userName, string titleGame, string count)
        {
            var result = statisticsRepository.UpdateStatistics(userName, titleGame, count);
            return result;
        }

        public bool DeleteStatistics(string userName, string titleGame)
        {
            var result = statisticsRepository.DeleteStatistics(userName, titleGame);
            return result;
        }

        public IEnumerable<Entities.Statistics> GetStatisticsCollection(string titleGame)
        {
            var statisticsCollection = statisticsRepository.GetStatisticsCollection(titleGame);
            return statisticsCollection;
        }

        public Entities.Statistics GetStatistics(string userName, string titleGame)
        {
            var statistics = statisticsRepository.GetStatistics(userName, titleGame);
            return statistics;
        }

        public string Test(string userName, string titleGame)
        {
            return userName + titleGame;
        }

        public bool IsExistUserName(string userName, string titleGame)
        {
            var isExist = statisticsRepository.IsExistUserName(userName, titleGame);
            return isExist;
        }
    }
}
