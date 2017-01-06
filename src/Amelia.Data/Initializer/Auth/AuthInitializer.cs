using System;
using System.Linq;
using Amelia.Data.Contexts;
using Amelia.Domain.Enums;
using Amelia.Domain.Models;

namespace Amelia.Data.Initializer.Auth
{


    public static class AuthInitializer
    {
        public static void UserAndRoles(AmeliaContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new Role[]{
                    new Role(){
                        Name =  "Admin"
                    }
                });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User()
                {
                    Email = "admin@amelia-pm.com",
                    Username = "admin",
                    Password = "9wsmLgYM5Gu4zA/BSpxK2GIBEWzqMPKs8wl2WDBzH/4=",
                    Salt = "GTtKxJA6xJuj3ifJtTXn9Q==",
                    Status = (short)UserStatus.Online,
                    CreatedOn = DateTime.Now
                });
                context.SaveChanges();

                context.UserRoles.AddRange(new UserRole[]{
                    new UserRole(){
                        RoleId = 1,
                        UserId = 1
                    }
                });

                context.SaveChanges();
            }

        }
    }
}