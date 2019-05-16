using System.Data.Entity;

namespace Aula1.Models.Db
{
    public class CursoExtensaoDbContext : DbContext
    {
        public CursoExtensaoDbContext() : base("name=CursoDBContext")
        {

        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}