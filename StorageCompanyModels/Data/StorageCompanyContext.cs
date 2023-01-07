using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StorageCompanyModels.Models;

namespace StorageCompanyModels.Data;

public partial class StorageCompanyContext : DbContext
{
    public StorageCompanyContext()
    {
    }

    public StorageCompanyContext(DbContextOptions<StorageCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<client> clients { get; set; }

    public virtual DbSet<clientscontentview> clientscontentviews { get; set; }

    public virtual DbSet<contact> contacts { get; set; }

    public virtual DbSet<contract> contracts { get; set; }

    public virtual DbSet<item> items { get; set; }

    public virtual DbSet<storage_content> storage_contents { get; set; }

    public virtual DbSet<storagehouse> storagehouses { get; set; }

    public virtual DbSet<task_add> task_adds { get; set; }

    public virtual DbSet<task_remove> task_removes { get; set; }

    private readonly HttpContext _httpContext;

    public StorageCompanyContext(DbContextOptions<StorageCompanyContext> options, IHttpContextAccessor httpContextAccessor = null)
       : base(options)
    {
        _httpContext = httpContextAccessor?.HttpContext;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        var claim_password = _httpContext.User.Claims.First(c => c.Type == "password");
        var password = claim_password.Value;
        var claim_login = _httpContext.User.Claims.First(c => c.Type == "login");
        var login = claim_login.Value;
        optionsBuilder.UseNpgsql($"Host = 127.0.0.1:5432;Database=StorageCompany;Username={login};Password={password}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<client>(entity =>
        {
            entity.HasKey(e => e.company_id).HasName("client_pkey");

            entity.HasOne(d => d.contact).WithMany(p => p.clients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_contact_id_fkey");

            entity.HasOne(d => d.contract).WithMany(p => p.clients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_contract_id_fkey");
        });

        modelBuilder.Entity<clientscontentview>(entity =>
        {
            entity.ToView("clientscontentview");
        });

        modelBuilder.Entity<contact>(entity =>
        {
            entity.HasKey(e => e.contact_id).HasName("contacts_pkey");
        });

        modelBuilder.Entity<contract>(entity =>
        {
            entity.HasKey(e => e.contract_id).HasName("contracts_pkey");
        });

        modelBuilder.Entity<item>(entity =>
        {
            entity.HasKey(e => e.item_id).HasName("items_pkey");
        });

        modelBuilder.Entity<storage_content>(entity =>
        {
            entity.HasKey(e => e.id).HasName("storage_contents_pkey");

            entity.HasOne(d => d.item).WithMany(p => p.storage_contents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("storage_contents_item_id_fkey");

            entity.HasOne(d => d.ownerNavigation).WithMany(p => p.storage_contents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("storage_contents_owner_fkey");

            entity.HasOne(d => d.storagehouse).WithMany(p => p.storage_contents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("storage_contents_storagehouse_id_fkey");
        });

        modelBuilder.Entity<storagehouse>(entity =>
        {
            entity.HasKey(e => e.storagehouse_id).HasName("storagehouses_pkey");
        });

        modelBuilder.Entity<task_add>(entity =>
        {
            entity.HasKey(e => e.task_id).HasName("task_add_pkey");

            entity.HasOne(d => d.contact).WithMany(p => p.task_adds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_add_contact_id_fkey");

            entity.HasOne(d => d.item).WithMany(p => p.task_adds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_add_item_id_fkey");

            entity.HasOne(d => d.storagehouse).WithMany(p => p.task_adds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_add_storagehouse_id_fkey");
        });

        modelBuilder.Entity<task_remove>(entity =>
        {
            entity.HasKey(e => e.task_id).HasName("task_remove_pkey");

            entity.HasOne(d => d.contact).WithMany(p => p.task_removes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_remove_contact_id_fkey");

            entity.HasOne(d => d.item).WithMany(p => p.task_removes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_remove_item_id_fkey");

            entity.HasOne(d => d.storagehouse).WithMany(p => p.task_removes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("task_remove_storagehouse_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
