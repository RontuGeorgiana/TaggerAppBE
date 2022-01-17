using Microsoft.EntityFrameworkCore;
using TaggerAppBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.One_to_Many;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Models.One_to_One;

namespace TaggerAppBE.Data
{
    public class TaggerContext: DbContext
    {
        public DbSet<DatabaseModel>DatabaseModels { get; set; }

        //One to Many
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        //One to One
        public DbSet<Profile> Profiles { get; set; }

        //Many to many
        public DbSet<Entry> Entries { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagEntryRelation>TagEntryRelations { get; set; }

        public DbSet<LikedCategory> LikedCategories { get; set; }

        public TaggerContext(DbContextOptions<TaggerContext>options): base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // one to many
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Entries)
                        .WithOne(e => e.Category);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Entries)
                        .WithOne(e => e.User);

            // one to one
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Profile)
                        .WithOne(p => p.User)
                        .HasForeignKey<Profile>(p => p.UserId);

            //many to many
            modelBuilder.Entity<TagEntryRelation>()
                        .HasKey(rel => new { rel.EntryId, rel.TagId });

            modelBuilder.Entity<TagEntryRelation>()
                        .HasOne<Entry>(rel => rel.Entry)
                        .WithMany(e => e.TagEntryRelations)
                        .HasForeignKey(rel => rel.EntryId);

            modelBuilder.Entity<TagEntryRelation>()
                        .HasOne<Tag>(rel => rel.Tag)
                        .WithMany(t => t.TagEntryRelations)
                        .HasForeignKey(rel => rel.TagId);

            modelBuilder.Entity<LikedCategory>()
                        .HasKey(like => new { like.ProfileId, like.CategoryId });

            modelBuilder.Entity<LikedCategory>()
                        .HasOne<Profile>(like => like.Profile)
                        .WithMany(p => p.LikedCategories)
                        .HasForeignKey(like => like.ProfileId);

            modelBuilder.Entity<LikedCategory>()
                        .HasOne<Category>(like => like.Category)
                        .WithMany(p => p.LikedCategories)
                        .HasForeignKey(like => like.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
