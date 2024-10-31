using Microsoft.EntityFrameworkCore;
using NinjaApp.Models;
namespace NinjaApp.DbAccess
{
    public class MyNinjaDbContext : DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<NinjaEquipment> NinjaEquipments { get; set; }
        public MyNinjaDbContext(DbContextOptions<MyNinjaDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Ninja-Equipment many-to-many relationship with composite key
            modelBuilder.Entity<NinjaEquipment>()
                .HasKey(ne => new { ne.NinjaId, ne.EquipmentId });

            modelBuilder.Entity<NinjaEquipment>()
                .HasOne(ne => ne.Ninja)
                .WithMany(n => n.NinjaEquipments)
                .HasForeignKey(ne => ne.NinjaId);

            modelBuilder.Entity<NinjaEquipment>()
                .HasOne(ne => ne.Equipment)
                .WithMany(e => e.NinjaEquipments)
                .HasForeignKey(ne => ne.EquipmentId);

            // Configure Ninja entity properties
            modelBuilder.Entity<Ninja>()
                .Property(n => n.Id);

            // Configure Equipment entity properties
            modelBuilder.Entity<Equipment>()
                .Property(e => e.Id);

            // Seed data
            modelBuilder.Entity<Ninja>().HasData(
                new Ninja { Id = 1, Name = "Shadow", AmountOfGold = 100 },
                new Ninja { Id = 2, Name = "Blade", AmountOfGold = 150 }
            );

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Sword", Type = EquipmentType.Hand, GoldWorth = 300, Strength = 10, Agility = 5, Intelligence = 2 },
                new Equipment { Id = 2, Name = "Helmet", Type = EquipmentType.Head, GoldWorth = 200, Strength = 5, Agility = 3, Intelligence = 1 }
            );

            modelBuilder.Entity<NinjaEquipment>().HasData(
                new NinjaEquipment { NinjaId = 1, EquipmentId = 1 },
                new NinjaEquipment { NinjaId = 2, EquipmentId = 2 }
            );
        }
    }
}