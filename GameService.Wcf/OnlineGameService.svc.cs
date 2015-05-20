using GameService.Entities;
using GameService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OnlineGameService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OnlineGameService.svc or OnlineGameService.svc.cs at the Solution Explorer and start debugging.
    public class OnlineGameService : IOnlineGameService
    {
        private OnlineGameRepository onlineGameRepository = null;

        public OnlineGameService()
        {
            onlineGameRepository = new OnlineGameRepository();
        }
        public bool CreateGame(string idFirstGamer)
        {
            var result = onlineGameRepository.CreateGame(idFirstGamer);
            return result;
        }

        public bool StartGame(string idGame, string idSecondGamer, string idCurrentGamer)
        {
            var result = onlineGameRepository.StartGame(idGame, idSecondGamer, idCurrentGamer);
            return result;
        }

        //public bool UpdateStatusGame(string idGame, string xmlCurrentStatus, string idGamer)
        //{
        //    var result = onlineGameRepository.UpdateStatusGame(idGame, xmlCurrentStatus, idGamer);
        //    return result;
        //}
        public bool UpdateStatusGame(UpdateStatus obj)
        {
            var result = onlineGameRepository.UpdateStatusGame(obj.IdGame, obj.IdGamer, obj.XmlCurrentStatus, obj.LastMovedCheckers, obj.LastDeletedCheckers);
            return result;
        }

        public string GetFullStatusGame(string idGame, string idGamer)
        {
            return onlineGameRepository.GetFullStatusGame(idGame, idGamer);
        }

        public StatusGame GetStatusGame(string idGame, string idGamer)
        {
            return onlineGameRepository.GetStatusGame(idGame, idGamer);
        }

        //public List<CheckersGame> GetGames(string userName, string online)
        //{
        //    var result = onlineGameRepository.GetGames(userName, online);
        //    return result;
        //}

        public List<CheckersGame> GetGames(string idCurrentGamer, string userName, string online)
        {
            var result = onlineGameRepository.GetGames(idCurrentGamer, userName, online);
            return result;
        }

        public List<CurrentGame> GetCurrentGames(string idCurrentGamer)
        {
            var result = onlineGameRepository.GetCurrentGames(idCurrentGamer);
            return result;
        }

        public InputGame CheckInputGame(string idFirstGamer)
        {
            var result = onlineGameRepository.CheckInputGame(idFirstGamer);
            return result;
        }

        public CurrentStatusGame GetCurrentStatusGame(string idGame)
        {
            var result = onlineGameRepository.GetCurrentStatusGame(idGame);
            return result;
        }

        public bool FinishGame(string idGame, string idWinner)
        {
            var result = onlineGameRepository.FinishGame(idGame, idWinner);
            return result;
        }

        public List<CurrentGame> GetFinishedGames(string idCurrentGamer)
        {
            var result = onlineGameRepository.GetFinishedGames(idCurrentGamer);
            return result;
        }
    }
}
