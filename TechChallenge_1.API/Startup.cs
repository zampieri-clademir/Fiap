using Microsoft.AspNetCore.HttpOverrides;
using NServiceBus.SimpleInjector;
using SimpleInjector;
using System.Diagnostics.CodeAnalysis;

using TechChallenge_1.API.Extensions;
using TechChallenge_1.Base.Configuracoes;
using TechChallenge_1.Domain;
using TechChallenge_1.Migracoes;

namespace TechChallenge_1.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private static Container Container { get; } = new Container();

        private readonly IConfiguration _configuracoes;

        private readonly GerenciamentoConfiguracoes _configuracoesApi;

        public Startup(IConfiguration configuration)
        {
            _configuracoes = configuration;

            _configuracoesApi = new GerenciamentoConfiguracoes();

            configuration.Bind(_configuracoesApi);

            Container.Options.AllowOverridingRegistrations = true;
            Container.Options.AutoWirePropertiesImplicitly();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddCors();
            services.AddSimpleInjector(Container);
            services.AddMediator(Container);
            services.AddValidators(Container);
            services.AddFilters();
            services.AddSwagger();
            services.AddMVC();
            services.AddHttpClient();
            services.InicializarDomain();
            services.AdicionarDependenciasBanco(_configuracoes);
            services.InicializarMigracoes(_configuracoes);

            services.AddTransient(c => _configuracoes);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            Container.AutoCrossWireAspNetComponents(app);

            app.UseAuthentication();

            app.UseMvc();

            app.ConfigSwagger();

            app.UseStaticFiles();

            Container.RegisterMvcControllers(app);
        }
    }
}