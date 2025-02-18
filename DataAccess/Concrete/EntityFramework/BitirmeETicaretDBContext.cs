﻿using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BitirmeETicaretDBContext : DbContext
    {
        public BitirmeETicaretDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            var result = 0;
            var i = 0;
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.createTime = DateTime.Now,
                    EntityState.Modified => data.Entity.updateTime = DateTime.Now,
                    EntityState.Deleted => data.Entity.updateTime =DateTime.Now,
                    EntityState.Unchanged => data.Entity.updateTime = DateTime.Now,
                };
                i++;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
