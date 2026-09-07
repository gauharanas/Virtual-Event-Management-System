using EMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DAL.DataAccess
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SpeakersDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Session → Event (Many-to-One)
            modelBuilder.Entity<SessionInfo>()
                .HasOne(s => s.Event)
                .WithMany()
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Session → Speaker (Optional)
            modelBuilder.Entity<SessionInfo>()
                .HasOne(s => s.Speaker)
                .WithMany()
                .HasForeignKey(s => s.SpeakerId)
                .OnDelete(DeleteBehavior.SetNull);

            //  Participant → Event
            modelBuilder.Entity<ParticipantEventDetails>()
                .HasOne(p => p.Event)
                .WithMany()
                .HasForeignKey(p => p.EventId);

            //  Participant → User
            modelBuilder.Entity<ParticipantEventDetails>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.ParticipantEmailId);

            //  Duplicate Registration
            modelBuilder.Entity<ParticipantEventDetails>()
                .HasIndex(p => new { p.ParticipantEmailId, p.EventId })
                .IsUnique();
        }
    }
}
