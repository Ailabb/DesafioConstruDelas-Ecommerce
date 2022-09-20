using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        //Mapeamento entre Classes e Objetos de banco. Só será necessário fazer o "Set" uma única vez.
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Produto> Produto => Set<Produto>();
        public DbSet<Pedido> Pedido => Set<Pedido>();
        public DbSet<ItemPedido> ItemPedido => Set<ItemPedido>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //TODO: Popular o Banco.
    }
}
