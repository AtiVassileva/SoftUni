using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FastFood.Data
{
    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            //TODO: Fix the connection string - Configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<FastFoodContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FastFood;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new FastFoodContext(builder.Options);
        }
    }
}
