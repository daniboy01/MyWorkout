using Microsoft.AspNetCore.Identity;
using MyWorkout.Dal.SeedInterfaces;
using MyWorkout.Dal.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Dal.SeedService
{
    public class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public RoleSeedService( RoleManager<IdentityRole<int>> roleManager )
        {
            this.roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            if( !await roleManager.RoleExistsAsync( Roles.Adminnistrator))
                await roleManager.CreateAsync(new IdentityRole<int> { Name = Roles.Adminnistrator });
            
        }
    }
}
