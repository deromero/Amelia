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
                    Email = "amelia-app@romerodev.com",
                    Username = "admin",
                    Password = "1xIo/zZ1UmMyX0CdxuokPqT/JDB/C7CjZta7ip/zTHg=",
                    Salt = "GvaJSm+xPQbqpq++yX9QNQ==",
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