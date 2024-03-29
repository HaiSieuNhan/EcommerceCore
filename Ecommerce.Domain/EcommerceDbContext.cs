﻿using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain
{
    public class EcommerceDbContext : DbContext
    {
       
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<PromotionProduct> PromotionProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Config> Configs { get; set; }
       // public DbSet<Language> Languages { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<HistoryDetail> HistoryDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
