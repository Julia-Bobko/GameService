using GameService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GameService.Entities;
using Checkers.Entities;

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

        //public int CreateGamer(string login, string email, string hashPassword)
        //{
        //    var isCreated = authorizeRepository.CreateGamer(login, email, hashPassword);
        //    return isCreated;
        //}
    }
}
