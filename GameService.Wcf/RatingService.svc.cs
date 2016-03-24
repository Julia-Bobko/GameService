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

        public bool CreateRating(Rating rating)
        {
            bool isCreated = RatingRepository.CreateRating(rating);
            return isCreated;
        }

        public Rating GetRating(string idGamer, string game)
        {
            Rating rating = RatingRepository.GetRating(idGamer, game);
            return rating;
        }

        public IEnumerable<Rating> GetRatings(string game)
        {
            var ratings = RatingRepository.GetRatings(game);
            return ratings;
        }

        public bool UpdateRating(Rating rating)
        {
            bool isUpdated = RatingRepository.UpdateRating(rating);
            return isUpdated;
        }
    }
}
