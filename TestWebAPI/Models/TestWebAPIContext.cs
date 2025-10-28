using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestWebAPI.Models;

public partial class TestWebAPIContext : DbContext
{
    public TestWebAPIContext()
    {
    }

    public TestWebAPIContext(DbContextOptions<TestWebAPIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-L65BNG88\\SQLEXPRESS;Database=TESTCONCEPT_DB;User ID=netappuser;Password=netapp123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Transaction");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
