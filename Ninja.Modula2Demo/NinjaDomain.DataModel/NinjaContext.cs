using System.Data.Entity;

namespace NinjaDomain.DataModel
{
    public class NinjaContext:DbContext
    {
        public DbSet<Classes.Classes.Ninja> Ninjas { get; set; }
        public DbSet<Classes.Classes.Clan> Clans { get; set; }
        public DbSet<Classes.Classes.NinjaEquipment> Equipment { get; set; }
    }
}
