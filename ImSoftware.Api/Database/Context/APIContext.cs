using System;
using System.Collections.Generic;
using ImSoftware.Api.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace ImSoftware.Api.Database.Context;

public partial class APIContext : DbContext
{
    public APIContext()
    {
    }

    public APIContext(DbContextOptions<APIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=helpdesk-dev-server.database.windows.net;Initial Catalog=imsoftware;Persist Security Info=False; User ID=helpdesk-admin;Password=h3lpd3sk-4dm1n!@#$");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
