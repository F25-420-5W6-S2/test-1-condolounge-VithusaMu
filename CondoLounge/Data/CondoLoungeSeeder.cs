using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data
{
    public class CondoLoungeSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ILogger<CondoLoungeSeeder> _logger;

        public CondoLoungeSeeder(ApplicationDbContext context,
            IWebHostEnvironment hosting,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            ILogger<CondoLoungeSeeder> logger)
        {
            _db = context;
            _hosting = hosting;    
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();

            _logger.LogInformation("Roles are being created...");
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
                _logger.LogInformation("Roles are done...");
            }

            Condo condo = null;
            if (!_db.Buildings.Any())
            {
                Building building = new Building();

                condo = new Condo()
                {
                    CondoNumber = 101,
                    BuildingId = building.Id,
                    Location = "Montreal"
                };

                building.Condos.Add(condo);

                _db.Buildings.Add(building);

                _db.SaveChanges();
                _logger.LogInformation("Building & condo creation are done...");
            }

            if (!_userManager.Users.Any())
            {
                var admin = new ApplicationUser() 
                { 
                    UserName = "admin@email.com", 
                    Email = "admin@email.com"
                };

                condo.Users.Add(admin);
                admin.Condos.Add(condo);

                _db.Condos.Add(condo);

                _db.SaveChanges();

                await _userManager.CreateAsync(admin, "VerySecureAdmin45%");
                await _userManager.AddToRoleAsync(admin, "Admin");
                _logger.LogInformation("Users are done...");
            }

            _db.SaveChanges();
        }

    }
}
