using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project17.Data
{
    public partial class Project17Context : DbContext
    {
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        public Project17Context(DbContextOptions<Project17Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.SupportRep)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.SupportRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.BillingAddress)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.BillingCity)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.BillingCountry)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.BillingPostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.BillingState)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Customer");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceLineId);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceItem_Invoice");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceItem_Track");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.TrackId });

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistTrack_Playlist");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.PlaylistTrack)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistTrack_Track");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.Composer)
                    .IsRequired()
                    .HasMaxLength(220);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Album");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Genre");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_MediaType");
            });
        }
    }
}
