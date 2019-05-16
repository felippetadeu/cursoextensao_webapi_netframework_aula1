using Aula1.Models.Db;
using System.Linq;

namespace Aula1.Servicos
{
    public class UsuarioSeguranca
    {
        public static bool Login(string email, string senha)
        {
            using (var db = new CursoExtensaoDbContext())
            {
                return db.Usuarios.Any(u => u.Email == email && u.Senha == senha);
            }
        }
    }
}