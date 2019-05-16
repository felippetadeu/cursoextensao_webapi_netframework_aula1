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
            return null;
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (UsuarioSeguranca.Login(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
                return null;
            }
            else
            {
                context.SetError("acesso inválido", "As credenciais do usuário não conferem....");
                return null;
            }
        }
    }
}