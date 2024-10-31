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

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "Helmet 1", Type = EquipmentType.Head, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 2, Name = "Boots 1", Type = EquipmentType.Feet, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 3, Name = "Ring 1", Type = EquipmentType.Ring, GoldWorth = 50, Strength = 5, Agility = 5, Intelligence = 0 },
                new Equipment { Id = 4, Name = "Gloves 1", Type = EquipmentType.Hand, GoldWorth = 20, Strength = 0, Agility = 0, Intelligence = 10 },
                new Equipment { Id = 5, Name = "Necklace 1", Type = EquipmentType.Necklace, GoldWorth = 30, Strength = 0, Agility = 10, Intelligence = 0 },
                new Equipment { Id = 6, Name = "Chestplate 1", Type = EquipmentType.Chest, GoldWorth = 80, Strength = 8, Agility = 8, Intelligence = 0 },
                new Equipment { Id = 7, Name = "Helmet 2", Type = EquipmentType.Head, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 8, Name = "Boots 2", Type = EquipmentType.Feet, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 9, Name = "Ring 2", Type = EquipmentType.Ring, GoldWorth = 50, Strength = 5, Agility = 5, Intelligence = 0 },
                new Equipment { Id = 10, Name = "Gloves 2", Type = EquipmentType.Hand, GoldWorth = 20, Strength = 0, Agility = 0, Intelligence = 10 },
                new Equipment { Id = 11, Name = "Necklace 2", Type = EquipmentType.Necklace, GoldWorth = 30, Strength = 0, Agility = 10, Intelligence = 0 },
                new Equipment { Id = 12, Name = "Chestplate 2", Type = EquipmentType.Chest, GoldWorth = 80, Strength = 8, Agility = 8, Intelligence = 0 },
                new Equipment { Id = 13, Name = "Helmet 3", Type = EquipmentType.Head, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 14, Name = "Boots 3", Type = EquipmentType.Feet, GoldWorth = 100, Strength = 10, Agility = 0, Intelligence = 0 },
                new Equipment { Id = 15, Name = "Ring 3", Type = EquipmentType.Ring, GoldWorth = 50, Strength = 5, Agility = 5, Intelligence = 0 },
                new Equipment { Id = 16, Name = "Gloves 3", Type = EquipmentType.Hand, GoldWorth = 20, Strength = 0, Agility = 0, Intelligence = 10 },
                new Equipment { Id = 17, Name = "Necklace 3", Type = EquipmentType.Necklace, GoldWorth = 30, Strength = 0, Agility = 10, Intelligence = 0 },
                new Equipment { Id = 18, Name = "Chestplate 3", Type = EquipmentType.Chest, GoldWorth = 80, Strength = 8, Agility = 8, Intelligence = 0 }
            );

            modelBuilder.Entity<Ninja>().HasData(
                new Ninja { AmountOfGold = 100, Id = 1, Name = "Ninja 1" }
                );
            
        }
    }
}