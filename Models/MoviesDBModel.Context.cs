namespace MovieApp.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class MoviesDBEntities : DbContext
    {
        public MoviesDBEntities()
            : base("name=MoviesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Movie> Movies { get; set; }

    }
}
