using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineShoppingCart.Models
{
    public partial class OnlineShoppingCartContext : DbContext
    {
        public OnlineShoppingCartContext()
        {
        }

        public OnlineShoppingCartContext(DbContextOptions<OnlineShoppingCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ShoppingSession> ShoppingSession { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<administrative_regions> administrative_regions { get; set; }
        public virtual DbSet<administrative_units> administrative_units { get; set; }
        public virtual DbSet<districts> districts { get; set; }
        public virtual DbSet<provinces> provinces { get; set; }
        public virtual DbSet<wards> wards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=OnlineShoppingCart;uid=sa;pwd=nvmduc;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.CartItemID)
                    .HasName("PK__CartItem__488B0B2A84D029EA");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.ProductID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("FK__CartItems__Produ__4D94879B");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.SessionID)
                    .HasConstraintName("FK__CartItems__Sessi__4E88ABD4");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Delete_at).HasColumnType("datetime");

                entity.Property(e => e.Descripton).HasColumnType("text");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Modified_at).HasColumnType("datetime");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Delete_at).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DiscountName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountPercent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Modified_at).HasColumnType("datetime");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.Property(e => e.Answer).HasColumnType("text");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.DateSend).HasColumnType("datetime");

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.Title).HasColumnType("text");

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FeedBack)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedBack__UserID__38996AB5");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK__OrderDeta__UserI__4316F928");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.OrderItems1)
                    .HasName("PK__OrderIte__99ED3BC4273044FB");

                entity.Property(e => e.OrderItems1).HasColumnName("OrderItems");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.ProductID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderDetailID)
                    .HasConstraintName("FK__OrderItem__Order__5165187F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductID)
                    .HasConstraintName("FK__OrderItem__Produ__52593CB8");
            });

            modelBuilder.Entity<PaymentDetails>(entity =>
            {
                entity.HasKey(e => e.PaymentID)
                    .HasName("PK__PaymentD__9B556A58B51D5798");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.OrderDetailID)
                    .HasConstraintName("FK__PaymentDe__Order__46E78A0C");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductID)
                    .HasName("PK__Products__B40CC6ED4899CE2C");

                entity.Property(e => e.ProductID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Delete_at).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .HasConstraintName("FK__Products__Catego__3F466844");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountID)
                    .HasConstraintName("FK__Products__Discou__403A8C7D");
            });

            modelBuilder.Entity<ShoppingSession>(entity =>
            {
                entity.HasKey(e => e.SessionID)
                    .HasName("PK__Shopping__C9F49270D02F051E");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingSession)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK__ShoppingS__UserI__49C3F6B7");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PK__Users__1788CCACF529599A");

                entity.Property(e => e.UserID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Created_at)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Delete_at).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Modified_at).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.districts_code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.provinces_code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.wards_code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.districts_codeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.districts_code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__districts__33D4B598");

                entity.HasOne(d => d.provinces_codeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.provinces_code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__provinces__32E0915F");

                entity.HasOne(d => d.wards_codeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.wards_code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__wards_cod__34C8D9D1");
            });

            modelBuilder.Entity<administrative_regions>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.code_name).HasMaxLength(255);

                entity.Property(e => e.code_name_en).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.name_en)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<administrative_units>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.code_name).HasMaxLength(255);

                entity.Property(e => e.code_name_en).HasMaxLength(255);

                entity.Property(e => e.full_name).HasMaxLength(255);

                entity.Property(e => e.full_name_en).HasMaxLength(255);

                entity.Property(e => e.short_name).HasMaxLength(255);

                entity.Property(e => e.short_name_en).HasMaxLength(255);
            });

            modelBuilder.Entity<districts>(entity =>
            {
                entity.HasKey(e => e.code)
                    .HasName("districts_pkey");

                entity.Property(e => e.code).HasMaxLength(20);

                entity.Property(e => e.code_name).HasMaxLength(255);

                entity.Property(e => e.full_name).HasMaxLength(255);

                entity.Property(e => e.full_name_en).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.name_en).HasMaxLength(255);

                entity.Property(e => e.province_code).HasMaxLength(20);

                entity.HasOne(d => d.administrative_unit_)
                    .WithMany(p => p.districts)
                    .HasForeignKey(d => d.administrative_unit_id)
                    .HasConstraintName("districts_administrative_unit_id_fkey");

                entity.HasOne(d => d.province_codeNavigation)
                    .WithMany(p => p.districts)
                    .HasForeignKey(d => d.province_code)
                    .HasConstraintName("districts_province_code_fkey");
            });

            modelBuilder.Entity<provinces>(entity =>
            {
                entity.HasKey(e => e.code)
                    .HasName("provinces_pkey");

                entity.Property(e => e.code).HasMaxLength(20);

                entity.Property(e => e.code_name).HasMaxLength(255);

                entity.Property(e => e.full_name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.full_name_en).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.name_en).HasMaxLength(255);

                entity.HasOne(d => d.administrative_region_)
                    .WithMany(p => p.provinces)
                    .HasForeignKey(d => d.administrative_region_id)
                    .HasConstraintName("provinces_administrative_region_id_fkey");

                entity.HasOne(d => d.administrative_unit_)
                    .WithMany(p => p.provinces)
                    .HasForeignKey(d => d.administrative_unit_id)
                    .HasConstraintName("provinces_administrative_unit_id_fkey");
            });

            modelBuilder.Entity<wards>(entity =>
            {
                entity.HasKey(e => e.code)
                    .HasName("wards_pkey");

                entity.Property(e => e.code).HasMaxLength(20);

                entity.Property(e => e.code_name).HasMaxLength(255);

                entity.Property(e => e.district_code).HasMaxLength(20);

                entity.Property(e => e.full_name).HasMaxLength(255);

                entity.Property(e => e.full_name_en).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.name_en).HasMaxLength(255);

                entity.HasOne(d => d.administrative_unit_)
                    .WithMany(p => p.wards)
                    .HasForeignKey(d => d.administrative_unit_id)
                    .HasConstraintName("wards_administrative_unit_id_fkey");

                entity.HasOne(d => d.district_codeNavigation)
                    .WithMany(p => p.wards)
                    .HasForeignKey(d => d.district_code)
                    .HasConstraintName("wards_district_code_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
