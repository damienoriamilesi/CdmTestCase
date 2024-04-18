using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Pizza> Pizzas { get; set; } = null!;
}

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}