using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class ApplicationUserRepository : CondoLoungeGenericGenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db, ILogger<ApplicationUserRepository> logger) : base(db, logger)
        {
        }
        public IEnumerable<ApplicationUser> GetUsersByBuilding(int buildingId)
        {
            return (IEnumerable<ApplicationUser>)_dbSet.Select(u => u.Condos.Where(c => c.BuildingId == buildingId)).ToList();
        }
    }
}
