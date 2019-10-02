﻿// <auto-generated />
using System;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNA.Infra.Data.Migrations
{
    [DbContext(typeof(DNAContext))]
    partial class DNAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DNA.Domain.Models.Cadastros.Common.Categorias.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("DNA.Domain.Models.Cadastros.Common.Expedidores.Expedidor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("CompanhiaNome")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Expedidores");
                });

            modelBuilder.Entity("DNA.Domain.Models.Cadastros.Common.Fornecedores.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Endereco");

                    b.Property<string>("EnderecoEmail")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("NomeCompanhia")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("NomeContato")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("TituloContato")
                        .IsRequired()
                        .HasColumnType("Varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("DNA.Domain.Models.Cadastros.Pessoas.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DNA.Domain.Models.Cadastros.Pessoas.Empregado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("DataAdmissao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Empregados");
                });
#pragma warning restore 612, 618
        }
    }
}
