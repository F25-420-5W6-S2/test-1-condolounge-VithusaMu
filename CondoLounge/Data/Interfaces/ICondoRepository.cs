using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface ICondoRepository : ICondoLoungeGenericRepository<Condo>
    {
        public IEnumerable<Condo> GetCondosByBuilding(int buildingId);
    }
}
