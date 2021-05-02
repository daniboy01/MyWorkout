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
            if ( !(await userManager.GetUsersInRoleAsync(Roles.Adminnistrator)).Any())
            {
                var user = new User
                {
                    Email = "admin@myworkout.hu",
                    DisplayName = "Adminisztrátor Aladár",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };

                var createResult = await userManager.CreateAsync(user, "$Admin123");
                var addToroleResult = await userManager.AddToRoleAsync(user, Roles.Adminnistrator);

                if (!createResult.Succeeded || !addToroleResult.Succeeded)
                    throw new ApplicationException("Aministrator could not be created!");
            }
        }
    }
}
