using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Govimithuro.Models;
using Govimithuro.Data;

namespace Govimithuro.Models
{
    public class GovimithuroDbContext : DbContext
    {
        public GovimithuroDbContext(DbContextOptions<GovimithuroDbContext> options)
            : base(options)
        {
        }

        // <summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
        }
        // </summary>
        public DbSet<Govimithuro.Models.User> UserTable{ get; set; }
        /// </summary>


        public DbSet<Govimithuro.Models.Admin> AdminTable { get; set; }
        public DbSet<Govimithuro.Models.Customer> CustomerTable { get; set; }
        public DbSet<Govimithuro.Models.Farmer> FarmerTable { get; set; }
        public DbSet<Govimithuro.Models.Order> OrderTable { get; set; }
        public DbSet<Govimithuro.Models.OrderDetails> OrderDetailsTable { get; set; }
        public DbSet<Govimithuro.Models.Product> ProductTable { get; set; }
        public DbSet<Govimithuro.Models.Cart> CartTable { get; set; }
        public DbSet<Govimithuro.Models.Category> CategoryTable { get; set; }
        public DbSet<Govimithuro.Models.BillingInfo> BillingInfoTable { get; set; }
        public DbSet<Govimithuro.Models.Login> LoginTable { get; set; }
        public DbSet<Govimithuro.Models.ClientQuery> ClientQueryTable { get; set; }
        public DbSet<Govimithuro.Models.DeliveryInfo> DeliveryInfoTable { get; set; }
        public DbSet<Govimithuro.Models.ProductCheck> ProductCheckTable { get; set; }
        public DbSet<Govimithuro.Models.Review> Review { get; set; }
    }



}
