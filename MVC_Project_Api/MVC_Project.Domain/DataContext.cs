using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Domain.Entities;

#nullable disable

namespace MVC_Project.Domain
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<DiscountProduct> ProductDiscounts { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.ApartmentNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Address_User_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Sum).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.HasMany(p => p.Products)
                    .WithMany(p => p.Carts)
                    .UsingEntity<CartProduct>(
                        j => j
                            .HasOne(d => d.Product)
                            .WithMany(p => p.CartProducts)
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CartProduct_Product_FK"),
                        j => j
                            .HasOne(d => d.Cart)
                            .WithMany(p => p.CartProducts)
                            .HasForeignKey(d => d.CartId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("CartProduct_Cart_FK"),
                        j =>
                        {
                            j.HasKey(e => new { e.CartId, e.ProductId })
                                .HasName("CartProduct_PK");
                            j.ToTable("CartProduct");
                            j.Property(e => e.Price).HasColumnType("decimal(6, 2)");
                        }
                    );
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.ChildCategories)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Category_Category_FK");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("Continent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.FlagUri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Country_Continent_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.SendDate)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(e => e.ShipmentIdFromDeliveryCompany)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingUrl)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeliveryType)
                    .WithMany()
                    .HasForeignKey(d => d.DeliveryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivery_DeliveryType_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<DeliveryCompany>(entity =>
            {
                entity.ToTable("DeliveryCompany");

                entity.Property(e => e.BaseTrackingUrl)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryType>(entity =>
            {
                entity.ToTable("DeliveryType");

                entity.Property(e => e.MaxWeight)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PredictedDeliveryDuration)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();

                entity.HasOne(d => d.DeliveryCompany)
                    .WithMany(p => p.DeliveryTypes)
                    .HasForeignKey(d => d.DeliveryCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DeliveryType_DeliveryCompany_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .IsRequired();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Address_FK")
                    .IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_User_FK")
                    .IsRequired();

                entity.HasOne(d => d.Voucher)
                    .WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Voucher_FK");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Category_FK")
                    .IsRequired();

                entity.HasMany(p => p.Discounts)
                    .WithMany(p => p.Products)
                    .UsingEntity<DiscountProduct>(
                        j => j
                            .HasOne(d => d.Discount)
                            .WithMany(p => p.ProductDiscounts)
                            .HasForeignKey(d => d.DiscountId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("DiscountProduct_Discount_FK"),
                        j => j
                            .HasOne(d => d.Product)
                            .WithMany(p => p.ProductDiscounts)
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("DiscountProduct_Product_FK"),
                        j =>
                        {
                            j.HasKey(e => new { e.ProductId, e.DiscountId })
                                .HasName("DiscountProduct_PK");
                            j.ToTable("DiscountProduct");
                        });

                entity.HasOne(d => d.Expert)
                    .WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Expert_FK");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Producer_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.ToTable("Theme");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Language_FK")
                    .IsRequired();

                entity.HasOne(d => d.TemporaryCart)
                    .WithOne(p => p.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Cart_FK");

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Theme_FK")
                    .IsRequired();
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.Rebate)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Voucher_User_FK")
                    .IsRequired();
            });
        }
    }
}
