using Microsoft.EntityFrameworkCore;


namespace CollectionWebApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Collection> Collections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DbSet<ItemHistory> ItemHistories { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role userRole = new() { Id = 1, Name = "admin" };
            Role adminRole = new() { Id = 2, Name = "user" };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });

            Status activeStatus = new() { Id = 1, Name = "active" };
            Status blockStatus = new() { Id = 2, Name = "block" };
            modelBuilder.Entity<Status>().HasData(new Status[] { blockStatus, activeStatus });

            modelBuilder.Entity<Topic>().HasData(new Topic[]
            {
                new() {Id = 1, Name = "Алкоголь"},
                new() {Id = 2, Name = "Книги"},
                new() {Id = 3, Name = "Рецепты"},
                new() {Id = 4, Name = "Животные"},
                new() {Id = 5, Name = "Растения"},
                new() {Id = 6, Name = "Одежда"}                
            }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
