using Aula1.Servicos;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aula1.Provider
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Método responsável por tornar válida a requisição de qualquer client
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Aqui é feita a verificação do usuário
            if (UsuarioSeguranca.Login(context.UserName, context.Password))
            {
                //Instanciado o objeto de identidade de direitos
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //Adicionado o direito sub com valor do nome do usuário
                identity.AddClaim(new Claim("sub", context.UserName));
                //Adicionado o direto role com valor user
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
                return Task.FromResult<object>(identity);
            }
            else
            {
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
            }

            return Task.FromResult<object>(null);
        }
    }
}