using System.Data.Entity;
using Gestion_Immobiliére.Models;

namespace GestionImmobiliere.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() :base(nameOrConnectionString:"MyConnection")
        {

        }
        public virtual DbSet<Owner> Owners { get; set; }
    }
}