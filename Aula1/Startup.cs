using System;
using System.Threading.Tasks;
using System.Web.Http;
using Aula1.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Aula1.Startup))]

namespace Aula1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configuração webapi
            var config = new HttpConfiguration();

            //configuração de rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                    name: "DefualtAPI",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

            //ativando cors
            app.UseCors(CorsOptions.AllowAll);

            //usar geração de token
            AtivarGeracaoTokenAcesso(app);

            //ativando configuração WebApi
            app.UseWebApi(config);
        }

        private void AtivarGeracaoTokenAcesso(IAppBuilder app)
        {
            var opcoes = new OAuthAuthorizationServerOptions()
            {
                /* Permite requisição HTTP, caso contrário somente HTTPS */
                AllowInsecureHttp = true,
                /* Qual url será executada para a obtenção do token*/
                TokenEndpointPath = new PathString("/token"),
                /* Em quanto tempo o token irá expirar*/
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                /* Quem irá prover o token */
                Provider = new ProviderDeTokensDeAcesso()
            };

            app.UseOAuthAuthorizationServer(opcoes);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
