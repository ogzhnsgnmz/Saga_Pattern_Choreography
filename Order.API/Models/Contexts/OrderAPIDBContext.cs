using Microsoft.EntityFrameworkCore;

namespace Order.API.Models.Contexts;

public class OrderAPIDBContext : DbContext
{
    public OrderAPIDBContext(DbContextOptions options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}