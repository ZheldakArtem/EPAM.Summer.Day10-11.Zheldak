namespace WebApplication1.codeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class codrFirst : DbContext
    {
        public codrFirst()
            : base("name=codrFirst")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("RoleUsers"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserFrom_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.UserTo_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Photos)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users1)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserUsers").MapRightKey("User_UserId1"));
        }
    }
}
