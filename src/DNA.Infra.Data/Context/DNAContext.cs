using DNA.Domain.Models.Cadastros.Common.Categorias;
using DNA.Domain.Models.Cadastros.Common.Expedidores;
using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Infra.Data.Mapping.Cadastros.Common.Categorias;
using DNA.Infra.Data.Mapping.Cadastros.Common.Expedidores;
using DNA.Infra.Data.Mapping.Cadastros.Common.Fornecedores;
using DNA.Infra.Data.Mapping.Cadastros.Pessoas.Clientes;
using DNA.Infra.Data.Mapping.Cadastros.Pessoas.Empregados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DNA.Infra.Data.Context
{
    public class DNAContext :DbContext
    {
        private readonly IHostingEnvironment _env;

        public DNAContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Expedidor> Expedidores { get; set; }
        public DbSet<Empregado> Empregados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new FornecedoreMap());
            modelBuilder.ApplyConfiguration(new ExpedidorMap());
            modelBuilder.ApplyConfiguration(new EmpregadoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
