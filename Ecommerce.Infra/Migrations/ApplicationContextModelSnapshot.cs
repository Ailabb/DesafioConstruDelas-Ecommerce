// <auto-generated />
using System;
using Ecommerce.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.Infra.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(1990, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Fernanda Santos"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(1990, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Maria Ferreira"
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Bianca Torres"
                        },
                        new
                        {
                            Id = 4,
                            DataNascimento = new DateTime(1994, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Amanda Gusmao"
                        },
                        new
                        {
                            Id = 5,
                            DataNascimento = new DateTime(1996, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Fernando Sampaio"
                        },
                        new
                        {
                            Id = 6,
                            DataNascimento = new DateTime(1989, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Bruno Gomes"
                        },
                        new
                        {
                            Id = 7,
                            DataNascimento = new DateTime(1987, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomeCliente = "Paula Motta"
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClienteId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClienteId = 3
                        },
                        new
                        {
                            Id = 3,
                            ClienteId = 2
                        },
                        new
                        {
                            Id = 4,
                            ClienteId = 6
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Caneta",
                            ValorUnitario = 1.5
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Borracha",
                            ValorUnitario = 2.0
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Caderno",
                            ValorUnitario = 12.0
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Estojo",
                            ValorUnitario = 20.0
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Mochila",
                            ValorUnitario = 50.0
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Bloco de Notas",
                            ValorUnitario = 2.2999999999999998
                        });
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Cliente", b =>
                {
                    b.OwnsOne("Ecommerce.Core.Entities.DadosContatoCliente", "Contato", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Celular")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ClienteId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("TelefoneResidencial")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("ClienteId")
                                .IsUnique();

                            b1.ToTable("DadosContatoCliente");

                            b1.WithOwner("Cliente")
                                .HasForeignKey("ClienteId");

                            b1.Navigation("Cliente");

                            b1.HasData(
                                new
                                {
                                    Id = 1,
                                    Celular = "71-987456688",
                                    ClienteId = 1,
                                    Email = "fernandaS@gmail.com",
                                    TelefoneResidencial = "71-33558877"
                                },
                                new
                                {
                                    Id = 2,
                                    Celular = "71-987875224",
                                    ClienteId = 2,
                                    Email = "marifer@gmail.com",
                                    TelefoneResidencial = "71-33557845"
                                },
                                new
                                {
                                    Id = 3,
                                    Celular = "71-976248688",
                                    ClienteId = 3,
                                    Email = "biancatorres@gmail.com",
                                    TelefoneResidencial = "71-32365877"
                                },
                                new
                                {
                                    Id = 4,
                                    Celular = "71-924598224",
                                    ClienteId = 4,
                                    Email = "mandagus@gmail.com",
                                    TelefoneResidencial = "71-37894645"
                                },
                                new
                                {
                                    Id = 5,
                                    Celular = "71-987878459",
                                    ClienteId = 5,
                                    Email = "fernandospr@gmail.com",
                                    TelefoneResidencial = "71-36877845"
                                },
                                new
                                {
                                    Id = 6,
                                    Celular = "71-987458688",
                                    ClienteId = 6,
                                    Email = "brunno.gomes@gmail.com",
                                    TelefoneResidencial = "71-33655877"
                                },
                                new
                                {
                                    Id = 7,
                                    Celular = "71-975648224",
                                    ClienteId = 7,
                                    Email = "paula_motta@gmail.com",
                                    TelefoneResidencial = "71-33584645"
                                });
                        });

                    b.Navigation("Contato");
                });

            modelBuilder.Entity("Ecommerce.Core.Entities.Pedido", b =>
                {
                    b.HasOne("Ecommerce.Core.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Ecommerce.Core.Entities.ItemPedido", "Itens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("PedidoId")
                                .HasColumnType("int");

                            b1.Property<int>("ProdutoId")
                                .HasColumnType("int");

                            b1.Property<int>("Quantidade")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PedidoId");

                            b1.HasIndex("ProdutoId");

                            b1.ToTable("ItemPedido");

                            b1.WithOwner("Pedido")
                                .HasForeignKey("PedidoId");

                            b1.HasOne("Ecommerce.Core.Entities.Produto", "Produto")
                                .WithMany()
                                .HasForeignKey("ProdutoId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Pedido");

                            b1.Navigation("Produto");

                            b1.HasData(
                                new
                                {
                                    Id = 1,
                                    PedidoId = 1,
                                    ProdutoId = 3,
                                    Quantidade = 2
                                },
                                new
                                {
                                    Id = 2,
                                    PedidoId = 1,
                                    ProdutoId = 4,
                                    Quantidade = 5
                                },
                                new
                                {
                                    Id = 3,
                                    PedidoId = 2,
                                    ProdutoId = 4,
                                    Quantidade = 2
                                },
                                new
                                {
                                    Id = 4,
                                    PedidoId = 2,
                                    ProdutoId = 5,
                                    Quantidade = 3
                                },
                                new
                                {
                                    Id = 5,
                                    PedidoId = 3,
                                    ProdutoId = 2,
                                    Quantidade = 5
                                },
                                new
                                {
                                    Id = 6,
                                    PedidoId = 4,
                                    ProdutoId = 4,
                                    Quantidade = 1
                                },
                                new
                                {
                                    Id = 7,
                                    PedidoId = 4,
                                    ProdutoId = 1,
                                    Quantidade = 2
                                },
                                new
                                {
                                    Id = 8,
                                    PedidoId = 4,
                                    ProdutoId = 5,
                                    Quantidade = 3
                                });
                        });

                    b.Navigation("Cliente");

                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
