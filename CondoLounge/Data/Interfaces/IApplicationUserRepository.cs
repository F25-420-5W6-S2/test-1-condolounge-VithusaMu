using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IApplicationUserRepository : ICondoLoungeGenericRepository<ApplicationUser>
    {
        public IEnumerable<ApplicationUser> GetUsersByBuilding(int buildingId);
    }
}
