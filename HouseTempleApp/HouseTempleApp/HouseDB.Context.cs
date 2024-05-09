namespace HouseTempleApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HouseTempleEntities : DbContext
    {
        private static HouseTempleEntities _context;

        public static HouseTempleEntities GetContext()
        {
            if (_context == null)
            {
                _context = new HouseTempleEntities();
            }
            return _context;
        }

        public HouseTempleEntities()
            : base("name=HouseTempleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Land> Land { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<RealEstate> RealEstate { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
