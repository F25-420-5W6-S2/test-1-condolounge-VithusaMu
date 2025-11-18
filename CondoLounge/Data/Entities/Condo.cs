using System.ComponentModel.DataAnnotations.Schema;

namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public int Id { get; set; }
        public int CondoNumber { get; set; }

        public string Location { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
    }
}
