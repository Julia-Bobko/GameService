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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdsGameService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdsGameService.svc or AdsGameService.svc.cs at the Solution Explorer and start debugging.
    public class AdsGameService : IAdsGameService
    {
        private AdsGameRepository AdsGameRepository { get; set; }

        public AdsGameService()
        {
            AdsGameRepository = new AdsGameRepository();
        }

        public IEnumerable<AdsGame> GetAdsGames(string language)
        {
            var adsGames = AdsGameRepository.GetAdsGames(language);
            return adsGames;
        }
    }
}
