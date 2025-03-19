using Microsoft.EntityFrameworkCore;

namespace WebApiStart.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        #region Dbset
        public DbSet<Book>? Books { get; set; }
        #endregion
    }
}
