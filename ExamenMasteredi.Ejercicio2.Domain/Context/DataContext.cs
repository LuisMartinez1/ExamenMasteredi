using ExamenMasteredi.Ejercicio2.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExamenMasteredi.Ejercicio2.Domain.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<EmisorEntity> Emisors { get; set; }
    }
}
