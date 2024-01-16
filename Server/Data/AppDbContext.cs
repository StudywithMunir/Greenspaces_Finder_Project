using Greenspaces_Finder.Shared;
using Microsoft.EntityFrameworkCore;

namespace Greenspaces_Finder.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<GreenSpace> GreenSpaces { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Admin> Admins { get; set; }

       

    }
}
