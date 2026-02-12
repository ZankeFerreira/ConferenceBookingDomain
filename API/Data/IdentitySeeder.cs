using Microsoft.AspNetCore.Identity;
using ConferenceBookingDomain.Domain;

public static class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { "Employee", "Admin", "Facilities_Manager", "Receptionist" };
        for (int i = 0; i < roles.Length; i++)
        {
            if (!await roleManager.RoleExistsAsync(roles[i]))
            {
                await roleManager.CreateAsync(new IdentityRole(roles[i]));
            }
        }

        var employee1 = await userManager.FindByNameAsync("Employee1");
        if (employee1 == null)
        {
            employee1 = new ApplicationUser
            {
                UserName = "Employee1",
                Email = "Employee1@company.com"
            };
            var result = await userManager.CreateAsync(employee1, "Employee1Password!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(employee1, "Employee");
            }
        }




        var employee2 = await userManager.FindByNameAsync("Employee2");
        if (employee2 == null)
        {
            employee2 = new ApplicationUser
            {
                UserName = "Employee2",
                Email = "Employee2@company.com"
            };
            var result = await userManager.CreateAsync(employee2, "Employee2Password!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(employee2, "Employee");
            }
        }

        var admin = await userManager.FindByNameAsync("Admin");
        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@company.com"
            };

            var result = await userManager.CreateAsync(admin, "Admin1Password!");
            if (result.Succeeded)
            {
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }

        var facliciesManager = await userManager.FindByNameAsync("Facilities_Manager");
        if (facliciesManager == null)
        {
            facliciesManager = new ApplicationUser
            {
                UserName = "Facilities_Manager",
                Email = "FacliciesManager@company.com"
            };

            var result = await userManager.CreateAsync(facliciesManager, "FaciliciesManager1Password!");
            if (result.Succeeded)
            {

                await userManager.AddToRoleAsync(facliciesManager, "Facilities_Manager");
            }
        }

        var receptionist = await userManager.FindByNameAsync("Receptionist");
        if (receptionist == null)
        {
            receptionist = new ApplicationUser
            {
                UserName = "Receptionist",
                Email = "Receptionist@company.com"
            };

            var result = await userManager.CreateAsync(receptionist, "Receptionist1Password!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(receptionist, "Receptionist");
            }
        }
    }
}
