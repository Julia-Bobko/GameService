using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameService.Entities;
using GameService.Repositories;

namespace GameService.Wcf
{
    public class RatingService : IRatingService
    {
        private RatingRepository RatingRepository { get; set; }

        public RatingService()
        {
            RatingRepository = new RatingRepository();
        }

        public bool CreateRatingPOST(Rating rating)
        {
            bool isCreated = RatingRepository.CreateRating(rating);
            return isCreated;
        }

        public bool CreateRatingGET(string idGamer, string game, string score, string additionalInfo)
        {
            Rating rating = new Rating
            {
                IdGamer = int.Parse(idGamer),
                Game = game,
                Score = int.Parse(score),
                AdditionalInfo = additionalInfo,
                LastDate = DateTime.Now
            };
            bool isCreated = RatingRepository.CreateRating(rating);
            return isCreated;
        }

        public Rating GetRating(string idGamer, string game)
        {
            Rating rating = RatingRepository.GetRating(idGamer, game);
            return rating;
        }

        public IEnumerable<RatingInfo> GetRatings(string game)
        {
            var ratings = RatingRepository.GetRatings(game);
            return ratings;
        }

        public bool UpdateRatingPOST(Rating rating)
        {
            bool isUpdated = RatingRepository.UpdateRating(rating);
            return isUpdated;
        }

        public bool UpdateRatingGET(string idGamer, string game, string score, string additionalInfo)
        {
            Rating rating = new Rating
            {
                IdGamer = int.Parse(idGamer),
                Game = game,
                Score = int.Parse(score),
                AdditionalInfo = additionalInfo,
                LastDate = DateTime.Now
            };
            bool isUpdated = RatingRepository.UpdateRating(rating);
            return isUpdated;
        }
    }
}
