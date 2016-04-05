using GameService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameService.Entities;
using Checkers.Entities;
using Newtonsoft.Json;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorizeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorizeService.svc or AuthorizeService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorizeService : IAuthorizeService
    {
        private AuthorizeRepository authorizeRepository = null;

        public AuthorizeService()
        {
            authorizeRepository = new AuthorizeRepository();
        }

        public int CreateGamer(Gamer obj)
        {
            int idGamer = authorizeRepository.CreateGamer(obj);
            return idGamer;
        }

        public int JVCreateGamerPOST(Gamer obj)
        {
            int idGamer = authorizeRepository.JVCreateGamer(obj);
            return idGamer;
        }

        //public int JVCreateGamerJSON(int a, DateTime b)
        //{
        //    //Gamer gamer = JsonConvert.DeserializeObject<Gamer>(obj);
        //    //int idGamer = authorizeRepository.JVCreateGamer(gamer);
        //    //return idGamer;
        //    return -1;
        //}

        public int JVCreateGamerGET(string socialId, string authentication, string imageSource, string firstName, string lastName, string city, string login, string email, string hashPassword, string resetPassword)
        {
            Gamer gamer = new Gamer
            {
                Authentication = authentication,
                City = city,
                Email = email,
                FirstName = firstName,
                HashPassword = hashPassword,
                ImageSource = imageSource,
                LastName = lastName,
                LastOnline = DateTime.Now,
                Login = login,
                ResetPassword = resetPassword
            };
            int idGamer = authorizeRepository.JVCreateGamer(gamer);
            return idGamer;
        }

        public int JVAuthorize(string login, string email, string hashPassword)
        {
            int idGamer = authorizeRepository.JVAuthorize(login, email, hashPassword);
            return idGamer;
        }

        //public int CreateGamer(string login, string email, string hashPassword)
        //{
        //    var isCreated = authorizeRepository.CreateGamer(login, email, hashPassword);
        //    return isCreated;
        //}
    }
}
