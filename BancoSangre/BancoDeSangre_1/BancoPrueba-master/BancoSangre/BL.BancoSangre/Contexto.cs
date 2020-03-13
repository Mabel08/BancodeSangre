using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.BancoSangre.ClientesBL;

namespace BL.BancoSangre
{
    public class Contexto: DbContext
    {
        public Contexto(): base("BancodeSangre2")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }

        public DbSet<Donantes> Donantes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public class Usuario
        {
            public int Id { get; set; }

            public string Nombre { get;  set; }
            public string password { get; set; }
        }
    }
}
