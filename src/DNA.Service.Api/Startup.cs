using DNA.CrossCutting.Identity.Authorization;
using DNA.CrossCutting.Identity.Data;
using DNA.CrossCutting.Identity.Models;
using DNA.CrossCutting.IoC;
using DNA.Service.Api.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DNA.Service.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", true, true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            })
           .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapperSetup();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteClienteData", policy => policy.Requirements.Add(new ClaimRequirement("Clientes", "Write")));
                options.AddPolicy("CanRemoveClienteData", policy => policy.Requirements.Add(new ClaimRequirement("Clientes", "Remove")));
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "DNA_Developers Project",
                    Description = "DNA_Devlolpers API Swagger surface",
                    Contact = new Contact { Name = "José Paulo", Email = "jose.galdino4@fatec.sp.gov.br", Url = "http://www.gmail.com" },
                    License = new License { Name = "MIT", Url = "https://github.com/PauloGaldino/DNA_Developers/blob/master/LICENSE" }
                });
            });

            // Adicionando o MediatR para eventos e notificações do domínio
            services.AddMediatR(typeof(Startup));

            // Abstração DI nativa do .NET
            RegisterServices(services);
        }

        // Este método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // O valor padrão do HSTS é de 30 dias. Convém alterar isso para cenários de produção, consultehttps://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "DNA_Devolupers Project API v1.1");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adicionando dependências de outras camadas (isoladas da apresentação)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

