using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class ApplicationUserRepository : CondoLoungeGenericGenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db, ILogger<ApplicationUserRepository> logger) : base(db, logger)
        {
        }
    }
}
