using Microsoft.AspNetCore.Identity;

public static class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string [] roles = {"Employee", "Admin", "Facilities Manager", "Receptionist"};
        for(int i = 0; i<roles.Length; i++)
        {
            if(!await roleManager.RoleExistsAsync(roles[i]))
            {
                await roleManager.CreateAsync(new IdentityRole(roles[i]));
            }            
        }

        var employee1 = await userManager.FindByNameAsync("Employee1");
        if(employee1 == null)
        {
            employee1 = new ApplicationUser
            {
                UserName = "Employee1",
                Email = "Employee1@company.com"
            };
            await userManager.CreateAsync(employee1, "Employee1Password");
        await userManager.AddToRoleAsync(employee1, "Employee");
        }

        


        var employee2 = await userManager.FindByNameAsync("Employee2");
        if(employee2 == null)
        {
            employee2 = new ApplicationUser
            {
                UserName = "Employee2",
                Email = "Employee2@company.com"
            };
            await userManager.CreateAsync(employee2, "Employee2Password");
            await userManager.AddToRoleAsync(employee2, "Employee");
        }

        var admin = await userManager.FindByNameAsync("Admin");
        if(admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@company.com"
            };

            await userManager.CreateAsync(admin, "AdminPassword");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        var facliciesManager = await userManager.FindByNameAsync("Faclicies_Manager");
        if(facliciesManager == null)
        {
            facliciesManager = new ApplicationUser
            {
                UserName = "Faclicies_Manager",
                Email = "FacliciesManager@company.com"
            };

            await userManager.CreateAsync(facliciesManager, "FacliciesManagerPassword");
            await userManager.AddToRoleAsync(facliciesManager, "Facilities Manager");
        }

        var receptionist = await userManager.FindByNameAsync("Receptionist");
        if(receptionist == null)
        {
            receptionist = new ApplicationUser
            {
                UserName = "Receptionist",
                Email = "Receptionist@company.com"
            };

            await userManager.CreateAsync(receptionist, "ReceptionistPassword");
            await userManager.AddToRoleAsync(receptionist, "Receptionist");
        }
    }
}