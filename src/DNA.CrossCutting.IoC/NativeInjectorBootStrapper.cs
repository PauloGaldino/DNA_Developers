using DNA.Application.Interfaces;
using DNA.Application.Services;
using DNA.CrossCutting.Bus;
using DNA.CrossCutting.Identity.Authorization;
using DNA.CrossCutting.Identity.Models;
using DNA.CrossCutting.Identity.Services;
using DNA.Domain.CommandHandlers;
using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Events.Interfaces;
using DNA.Domain.Core.Notifications;
using DNA.Domain.EventHandlers.Casdastros.Pessoas.Clientes;
using DNA.Domain.Events.Cadastros.Pessoas.Clientes;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Clientes;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Usuarios;
using DNA.Infra.Data.Context;
using DNA.Infra.Data.EventSourcing;
using DNA.Infra.Data.Repository.Cadastros.Pessoas.Clientes;
using DNA.Infra.Data.Repository.EventSourcing;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using DNA.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DNA.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ClienteRegisteredEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteUpdatedEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteRemovedEvent>, ClienteEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, bool>, ClienteCommandHandler>();

            // Infra - Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DNAContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}