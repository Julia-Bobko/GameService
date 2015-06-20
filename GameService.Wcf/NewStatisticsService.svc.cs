using GameService.Entities;
using GameService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewStatisticsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewStatisticsService.svc or NewStatisticsService.svc.cs at the Solution Explorer and start debugging.
    public class NewStatisticsService : INewStatisticsService
    {
        NewStatisticsRepository newStatisticsRepository = null;
        public NewStatisticsService()
        {
            newStatisticsRepository = new NewStatisticsRepository();
        }
        public bool CreateStatistics(NewStatistics obj)
        {
            var result = newStatisticsRepository.CreateStatistics(obj);
            return result;
        }

        public bool UpdateStatistics(NewStatistics obj)
        {
            var result = newStatisticsRepository.UpdateStatistics(obj);
            return result;
        }

        public bool UpdateStatisticsWithoutProgress(NewStatistics obj)
        {
            var result = newStatisticsRepository.UpdateStatistics(obj, false);
            return result;
        }

        public bool DeleteStatistics(string userId, string game)
        {
            var result = newStatisticsRepository.DeleteStatistics(userId, game);
            return result;
        }

        public IEnumerable<NewStatistics> GetStatisticsCollection(string game)
        {
            var statisticsCollection = newStatisticsRepository.GetStatisticsCollection(game);
            return statisticsCollection;
        }

        public NewStatistics GetStatistics(string userId, string game)
        {
            var statistics = newStatisticsRepository.GetStatistics(userId, game);
            return statistics;
        }
        

        public bool IsExistUserName(string userName, string titleGame)
        {
            var isExist = newStatisticsRepository.IsExistUserName(userName, titleGame);
            return isExist;
        }


        public IEnumerable<NewStatistics> GetStatisticsCollectionByCity(string game, string city)
        {
            var statisticsCollection = newStatisticsRepository.GetStatisticsCollectionByCity(game, city);
            return statisticsCollection;
        }

        public IEnumerable<NewStatistics> GetStatisticsCollectionBySocial(string game, string social)
        {
            var statisticsCollection = newStatisticsRepository.GetStatisticsCollectionBySocial(game, social);
            return statisticsCollection;
        }
    }
}
