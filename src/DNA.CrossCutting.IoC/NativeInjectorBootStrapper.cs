using DNA.Application.Interfaces.Cadastro.Common.Categorias;
using DNA.Application.Interfaces.Cadastro.Common.Expedidor;
using DNA.Application.Interfaces.Cadastro.Common.Fornecedores;
using DNA.Application.Interfaces.Cadastro.Pessoas.Clientes;
using DNA.Application.Interfaces.Cadastro.Pessoas.Empregados;
using DNA.Application.Services.Cadastro.Common.Categorias;
using DNA.Application.Services.Cadastro.Common.Expedidores;
using DNA.Application.Services.Cadastro.Common.Fornecedores;
using DNA.Application.Services.Cadastro.Pessoas.Clientes;
using DNA.Application.Services.Cadastro.Pessoas.Empregados;
using DNA.CrossCutting.Bus;
using DNA.CrossCutting.Identity.Authorization;
using DNA.CrossCutting.Identity.Models;
using DNA.CrossCutting.Identity.Services;
using DNA.Domain.CommandHandlers.Cadastros.Comman.Categorias;
using DNA.Domain.CommandHandlers.Cadastros.Comman.Expedidores;
using DNA.Domain.CommandHandlers.Cadastros.Comman.Fornecedores;
using DNA.Domain.CommandHandlers.Cadastros.Pessoas.Clientes;
using DNA.Domain.CommandHandlers.Cadastros.Pessoas.Empregados;
using DNA.Domain.Commands.Cadastros.Common.Categorias;
using DNA.Domain.Commands.Cadastros.Common.Expedidores;
using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;
using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Events.Interfaces;
using DNA.Domain.Core.Notifications;
using DNA.Domain.EventHandlers.Cadastros.Common.Categorias;
using DNA.Domain.EventHandlers.Cadastros.Common.Expedidores;
using DNA.Domain.EventHandlers.Cadastros.Pessoas.Empregados;
using DNA.Domain.EventHandlers.Cadatros.Common.Fornecedores;
using DNA.Domain.EventHandlers.Casdastros.Pessoas.Clientes;
using DNA.Domain.Events.Cadastros.Common.Categorias;
using DNA.Domain.Events.Cadastros.Common.Expedidores;
using DNA.Domain.Events.Cadastros.Common.Fornecedores;
using DNA.Domain.Events.Cadastros.Pessoas.Clientes;
using DNA.Domain.Events.Cadastros.Pessoas.Empregados;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Common.Categorias;
using DNA.Domain.Interfaces.Cadastros.Common.Expedidores;
using DNA.Domain.Interfaces.Cadastros.Common.Fornecedores;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Clientes;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Empregados;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Usuarios;
using DNA.Infra.Data.Context;
using DNA.Infra.Data.EventSourcing;
using DNA.Infra.Data.Repository.Cadastros.Commmon.Categorias;
using DNA.Infra.Data.Repository.Cadastros.Commmon.Fornecedores;
using DNA.Infra.Data.Repository.Cadastros.Common.Expedidores;
using DNA.Infra.Data.Repository.Cadastros.Pessoas.Clientes;
using DNA.Infra.Data.Repository.Cadastros.Pessoas.Empregados;
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


            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            //===================================================================================================
            services.AddScoped<IClienteAppService, ClienteAppService>();

            services.AddScoped<ICategoriaAppService, CategoriaAppService>();

            services.AddScoped<IFornecedorAppService, FornecedorAppService>();

            services.AddScoped<IExpedidorAppService, ExpedidorAppService>();

            services.AddScoped<IEmpregadoAppService, EmpregadoAppService>();

            //Domaain
            //=================================================================================================== 
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            // Domain - Events 
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Cliente
            services.AddScoped<INotificationHandler<ClienteRegisteredEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteUpdatedEvent>, ClienteEventHandler>();
            services.AddScoped<INotificationHandler<ClienteRemovedEvent>, ClienteEventHandler>();

            //Categoria
            services.AddScoped<INotificationHandler<CategoriaRegisteredEvent>, CategoriaEventHandler>();
            services.AddScoped<INotificationHandler<CategoriaUpdatedEvent>, CategoriaEventHandler>();
            services.AddScoped<INotificationHandler<CategoriaRemovedEvent>, CategoriaEventHandler>();

            //Fornecedor
            services.AddScoped<INotificationHandler<FornecedorRegisteredEvent>, FornecedorEventHandler>();
            services.AddScoped<INotificationHandler<FornecedorUpdatedEvent>, FornecedorEventHandler>();
            services.AddScoped<INotificationHandler<FornecedorRemovedEvent>, FornecedorEventHandler>();

            //Expedidor
            services.AddScoped<INotificationHandler<ExpedidorRegisteredEvent>, ExpedidorEventHandler>();
            services.AddScoped<INotificationHandler<ExpedidorUpdatedEvent>, ExpedidorEventHandler>();
            services.AddScoped<INotificationHandler<ExpedidorRemovedEvent>, ExpedidorEventHandler>();

            //Empregado
            services.AddScoped<INotificationHandler<EmpregadoRegisteredEvent>, EmpregadoEventHandler>();
            services.AddScoped<INotificationHandler<EmpregadoUpdatedEvent>, EmpregadoEventHandler>();
            services.AddScoped<INotificationHandler<EmpregadoRemovedEvent>, EmpregadoEventHandler>();

            // Domain - Commands
            //Cliente
            services.AddScoped<IRequestHandler<RegisterNewClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, bool>, ClienteCommandHandler>();

            //Categoria
            services.AddScoped<IRequestHandler<RegisterNewCategoriaCommand, bool>, CategoriaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoriaCommand, bool>, CategoriaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoriaCommand, bool>, CategoriaCommandHandler>();

            //Fornecedores
            services.AddScoped<IRequestHandler<RegisterNewFornecedorCommand, bool>, FornecedorCommandtHandler>();
            services.AddScoped<IRequestHandler<UpdateFornecedorCommand, bool>, FornecedorCommandtHandler>();
            services.AddScoped<IRequestHandler<RemoveFornecedorCommand, bool>, FornecedorCommandtHandler>();

            //Expedidores
            services.AddScoped<IRequestHandler<RegisterNewExpedidorCommand, bool>, ExpedidorCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateExpedidorCommand, bool>, ExpedidorCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveExpedidorCommand, bool>, ExpedidorCommandHandler>();


            //Empregados
            services.AddScoped<IRequestHandler<RegisterNewEmpregadoCommand, bool>, EmpregadoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEmpregadoCommand, bool>, EmpregadoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveEmpregadoCommand, bool>, EmpregadoCommandHandler>();

            //Infrastructure
            //=====================================================================================================
            // Infra - Data
            //Repository
            //Cliente
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //Categoria
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            //Fornecedor
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            //Expedidor
            services.AddScoped<IExpedidorRepository, ExpedidorRepository>();

            //Empregado
            services.AddScoped<IEmpregadoRepository, EmpregadoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DNAContext>();

            // Infra - Data 
            //EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity 
            //Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}