using Microsoft.AspNetCore.Identity;
using MyWorkout.Dal.Entities;
using MyWorkout.Dal.SeedInterfaces;
using MyWorkout.Dal.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Dal.SeedService
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<User> userManager;

        public UserSeedService( UserManager<User> userManager )
        {
            this.userManager = userManager;
        }
        public async Task SeedUserAsync()
        {
            if ( !(await userManager.GetUsersInRoleAsync(Roles.Administrator)).Any())
            {
                var admin = new User
                {
                    Email = "admin@myworkout.hu",
                    DisplayName = "Adminisztrátor Aladár",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };

                var user = new User
                {
                    Email = "user@myworkout.hu",
                    DisplayName = "User István",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "user"
                };

                var createResult_admin = await userManager.CreateAsync(admin, "$Admin123");
                var addToroleResult_admin = await userManager.AddToRoleAsync(admin, Roles.Administrator);

                var createResult_user = await userManager.CreateAsync(user, "$Password123");
                var addToroleResult_user = await userManager.AddToRoleAsync(user, Roles.User);

                if (!createResult_admin.Succeeded || !addToroleResult_admin.Succeeded)
                    throw new ApplicationException("Aministrator could not be created!");


                if (!createResult_user.Succeeded || !addToroleResult_user.Succeeded)
                    throw new ApplicationException("Aministrator could not be created!");

            }
        }
    }
}
