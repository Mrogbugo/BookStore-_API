using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Entities
{
    public class BookStoreContext : DbContext 
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options) 
        {
            
        } 

        public DbSet<Book> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server.;Database=BookStoreAPI;integrated Security = True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }  

   


}
