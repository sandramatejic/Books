using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.DataBase
{
    public static class DataUsers
    {
        public static List<User> users = new List<User>()
        {
            new User {IdUser= 1, FirstName= "Sandra", LastName= "Matejic", Email= "sandramatejic0@gmail.com", Password="sandra1234"}
        };

        public static void AddUser(User user)
        {
            users.Add(user);
        }

    }
}