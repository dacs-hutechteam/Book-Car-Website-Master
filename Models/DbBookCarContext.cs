using System.Data.Entity;

namespace BookCarProjectMaster.Models
{
    public partial class DbBookCarContext : DbContext
    {
        public DbBookCarContext()
            : base("name=DbBookCarContext")
        {
        }
        //Đây Là Lớp DAO Quản Lý Entity Framework để quản lý các dử liệu từ database
        //Bạn mở tệp Web.config trong thư mục gốc project ra và bổ sung thẻ connectionStrings vào trong thẻ configuration với các thông số kế nối với sever database của máy
        //public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BookCar> BookCars { get; set; }
        public virtual DbSet<CarCategory> CarCategories { get; set; }
        public virtual DbSet<CarProduct> CarProducts { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<GearBox> GearBoxs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BookCar>()
                .Property(e => e.TotalRental)
                .HasPrecision(19, 1);

            modelBuilder.Entity<BookCar>()
                .Property(e => e.CardIDUser)
                .IsUnicode(false);

            modelBuilder.Entity<BookCar>()
                .Property(e => e.NumberPhoneUser)
                .IsUnicode(false);

            modelBuilder.Entity<CarCategory>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.CarCategory)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CarProduct>()
                .Property(e => e.RentCost)
                .HasPrecision(19, 0);

            modelBuilder.Entity<CarProduct>()
                .HasMany(e => e.BookCars)
                .WithOptional(e => e.CarProduct)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Fuel>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.Fuel)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GearBox>()
                .HasMany(e => e.CarProducts)
                .WithOptional(e => e.GearBox)
                .WillCascadeOnDelete();
        }
    }
}
