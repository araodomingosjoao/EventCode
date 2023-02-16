using EventCode.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using System;

namespace EventCode.Context
{
    public class MySQLContext  : DbContext 
    {
        public MySQLContext() { }

        public MySQLContext (DbContextOptions<MySQLContext> options) : base(options)
        {}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var builder = modelBuilder.Entity<User>().ToTable("tb_users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnType("varchar(50)").HasColumnName("name").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").HasColumnName("email").IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar(20)").HasColumnName("phone_number").IsRequired();
            builder.Property(x => x.BI).HasColumnType("varchar(100)").HasColumnName("bi").IsRequired();
            builder.Property(x => x.QrCode).HasColumnType("varchar(244)").HasColumnName("qrcode").IsRequired();
            builder.Property(x => x.Status).HasColumnName("status").IsRequired();
            builder.Property(x => x.Created_At).HasColumnName("created_at").HasDefaultValue(DateTime.Now).IsRequired();
        }
    }
}
