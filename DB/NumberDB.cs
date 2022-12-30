using Microsoft.EntityFrameworkCore;
using Sorter.Models;

namespace Sorter.DB
{
    public class NumberDB : DbContext
    {
        public NumberDB(DbContextOptions<NumberDB> options) : base(options) { }
        public DbSet<Number> Numbers => Set<Number>();
    }
}
