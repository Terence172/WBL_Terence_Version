using AlphaZero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaZero.Services
{
    public class UserService
    {
        private readonly db_roomrentalEntities _db;

        public UserService(db_roomrentalEntities db)
        {
            _db = db;
        }

        public void CreateUser(string user_password, string user_name, string user_email)
        {
            var user = new user
            {
                user_password = user_password,
                user_name = user_name,
                user_email = user_email,
                user_type = "2" // Investor user type
            };

            _db.users.Add(user);
            _db.SaveChanges();
        }
    }
}