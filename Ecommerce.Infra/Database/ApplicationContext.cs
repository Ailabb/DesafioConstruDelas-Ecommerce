using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Ecommerce.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        //Mapeamento entre Classes e Objetos de banco. Só será necessário fazer o "Set" uma única vez.
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Produto> Produto => Set<Produto>();
        public DbSet<Pedido> Pedido => Set<Pedido>();
        public DbSet<ItemPedido> ItemPedido => Set<ItemPedido>();
        public DbSet<DadosContatoCliente> DadosContatoCliente => Set<DadosContatoCliente>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //TODO: Popular o Banco.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Caneta",
                    ValorUnitario = 1.50
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Borracha",
                    ValorUnitario = 2.00
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Caderno",
                    ValorUnitario = 12.00
                },
                new Produto
                {
                    Id = 4,
                    Nome = "Estojo",
                    ValorUnitario = 20.00
                },
                new Produto
                {
                    Id = 5,
                    Nome = "Mochila",
                    ValorUnitario = 50.00
                },
                new Produto
                {
                    Id = 6,
                    Nome = "Bloco de Notas",
                    ValorUnitario = 2.30
                }
            );
            
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 1,
                    NomeCliente = "Fernanda Santos",
                    DataNascimento = new DateTime(1990, 01, 30),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 1,
                    ClienteId = 1,
                    Celular = "71-987456688",
                    TelefoneResidencial = "71-33558877",
                    Email = "fernandaS@gmail.com",
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 2,
                    NomeCliente = "Maria Ferreira",                    
                    DataNascimento = new DateTime(1990, 01, 30),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 2,
                    ClienteId = 2,
                    Celular = "71-987875224",
                    TelefoneResidencial = "71-33557845",
                    Email = "marifer@gmail.com"
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 3,
                    NomeCliente = "Bianca Torres",
                    DataNascimento = new DateTime(1988, 08, 25),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 3,
                    ClienteId = 3,
                    Celular = "71-976248688",
                    TelefoneResidencial = "71-32365877",
                    Email = "biancatorres@gmail.com"
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 4,
                    NomeCliente = "Amanda Gusmao",
                    DataNascimento = new DateTime(1994, 11, 05),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 4,
                    ClienteId = 4,
                    Celular = "71-924598224",
                    TelefoneResidencial = "71-37894645",
                    Email = "mandagus@gmail.com"
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 5,
                    NomeCliente = "Fernando Sampaio",
                    DataNascimento = new DateTime(1996, 09, 08),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 5,
                    ClienteId = 5,
                    Celular = "71-987878459",
                    TelefoneResidencial = "71-36877845",
                    Email = "fernandospr@gmail.com"
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 6,
                    NomeCliente = "Bruno Gomes",
                    DataNascimento = new DateTime(1989, 06, 18),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 6,
                    ClienteId = 6,
                    Celular = "71-987458688",
                    TelefoneResidencial = "71-33655877",
                    Email = "brunno.gomes@gmail.com"
                });
            });
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasData(new Cliente
                {
                    Id = 7,
                    NomeCliente = "Paula Motta",
                    DataNascimento = new DateTime(1987, 02, 13),
                });
                c.OwnsOne(d => d.Contato).HasData(new DadosContatoCliente
                {
                    Id = 7,
                    ClienteId = 7,
                    Celular = "71-975648224",
                    TelefoneResidencial = "71-33584645",
                    Email = "paula_motta@gmail.com"
                });
            });
            modelBuilder.Entity<Pedido>(p =>
            {
                p.HasData(new Pedido
                {
                    Id = 1,
                    ClienteId = 1,
                });
                p.OwnsMany(i => i.Itens).HasData(new List<ItemPedido>
                   {
                       new ItemPedido
                       {
                           Id = 1,
                           PedidoId = 1,
                           ProdutoId= 3,
                           Quantidade = 2,                           
                       },
                       new ItemPedido
                       {
                           Id = 2,
                           PedidoId = 1,
                           ProdutoId= 4,
                           Quantidade = 5
                       }
                   });
            });
            modelBuilder.Entity<Pedido>(p =>
            {
                p.HasData(new Pedido
                {
                    Id = 2,
                    ClienteId = 3,
                });
                p.OwnsMany(i => i.Itens).HasData(new List<ItemPedido>
                   {
                       new ItemPedido
                       {
                           Id = 3,
                           PedidoId = 2,
                           ProdutoId= 4,
                           Quantidade = 2,
                       },
                       new ItemPedido
                       {
                           Id = 4,
                           PedidoId = 2,
                           ProdutoId= 5,
                           Quantidade = 3
                       }
                   });
            });
            modelBuilder.Entity<Pedido>(p =>
            {
                p.HasData(new Pedido
                {
                    Id = 3,
                    ClienteId = 2,
                });
                p.OwnsMany(i => i.Itens).HasData(new List<ItemPedido>
                   {
                       new ItemPedido
                       {
                           Id = 5,
                           PedidoId = 3,
                           ProdutoId= 2,
                           Quantidade = 5,
                       }
                      
                   });
            });
            modelBuilder.Entity<Pedido>(p =>
            {
                p.HasData(new Pedido
                {
                    Id = 4,
                    ClienteId = 6,
                });
                p.OwnsMany(i => i.Itens).HasData(new List<ItemPedido>
                   {
                       new ItemPedido
                       {
                           Id = 6,
                           PedidoId = 4,
                           ProdutoId= 4,
                           Quantidade = 1,
                       },
                        new ItemPedido
                       {
                           Id = 7,
                           PedidoId = 4,
                           ProdutoId= 1,
                           Quantidade = 2,
                       },
                         new ItemPedido
                       {
                           Id = 8,
                           PedidoId = 4,
                           ProdutoId= 5,
                           Quantidade = 3,
                       }

                   });
            });

        }
    }
        
}
