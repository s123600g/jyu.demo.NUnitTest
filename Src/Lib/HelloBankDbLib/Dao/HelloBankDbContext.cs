using System;
using System.Collections.Generic;
using HelloBankDbLib.DaoModels;
using Microsoft.EntityFrameworkCore;

namespace HelloBankDbLib.Dao;

public partial class HelloBankDbContext : DbContext
{
    public HelloBankDbContext()
    {
    }

    public HelloBankDbContext(DbContextOptions<HelloBankDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountAmount> AccountAmounts { get; set; }

    public virtual DbSet<CustAccountMapping> CustAccountMappings { get; set; }

    public virtual DbSet<CustInfo> CustInfos { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlite("Data Source=C:/Project/GitHub/jyu.demo.NUnitTest/Src/HelloBank.Web.Api/Db/HelloBank.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountAmount>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("ACCOUNT_AMOUNT");

            entity.Property(e => e.AccountNo)
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("ACCOUNT_NO");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMERIC(14,6)")
                .HasColumnName("AMOUNT");
        });

        modelBuilder.Entity<CustAccountMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUST_ACCOUNT_MAPPING");

            entity.Property(e => e.AccountNo)
                .HasColumnType("VARCHAR(14)")
                .HasColumnName("ACCOUNT_NO");
            entity.Property(e => e.CustId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("CUST_ID");
        });

        modelBuilder.Entity<CustInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUST_INFO");

            entity.Property(e => e.CustId)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("CUST_ID");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
