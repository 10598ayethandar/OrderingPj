namespace Ordering
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Order_Status> Order_Status { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderWith> OrderWiths { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Payment_Status> Payment_Status { get; set; }
        public virtual DbSet<OrderCompleteInfo> OrderCompleteInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Foods)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Food_CateId);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Confirm_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderWiths)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Food>()
                .Property(e => e.Food_name)
                .IsUnicode(false);

            modelBuilder.Entity<Order_Status>()
                .HasMany(e => e.OrderWiths)
                .WithRequired(e => e.Order_Status)
                .HasForeignKey(e => e.OrderStatus_Id);

            modelBuilder.Entity<OrderWith>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.OrderWith)
                .HasForeignKey(e => e.Order_Id);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.OrderWiths)
                .WithRequired(e => e.Payment)
                .HasForeignKey(e => e.Payment_Id);

            modelBuilder.Entity<Payment_Status>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Payment_Status)
                .HasForeignKey(e => e.Pay_Status);

            modelBuilder.Entity<OrderCompleteInfo>()
                .Property(e => e.Food_name)
                .IsUnicode(false);
        }
    }
}
