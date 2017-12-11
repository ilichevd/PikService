namespace DataAccessLevel.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PikDbContext : DbContext
    {
        // Your context has been configured to use a 'PikDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLevel.PikDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PikDbContext' 
        // connection string in the application configuration file.
        public PikDbContext()
            : base("name=PikDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Catalog> catalogs { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Task> tasks { get; set; }
    }
}