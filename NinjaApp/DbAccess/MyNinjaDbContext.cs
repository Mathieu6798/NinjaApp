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
                new Equipment { Id = 1, Name = "Diamond Sword", Type = EquipmentType.Hand, GoldWorth = 100, Strength = 20, Agility = 5, Intelligence = 3 },
                new Equipment { Id = 2, Name = "Diamond Helmet", Type = EquipmentType.Head, GoldWorth = 35, Strength = 8, Agility = 4, Intelligence = 2 },
                new Equipment { Id = 3, Name = "Diamond Chestplate", Type = EquipmentType.Chest, GoldWorth = 50, Strength = 12, Agility = 6, Intelligence = 3 },
                new Equipment { Id = 4, Name = "Diamond Boots", Type = EquipmentType.Feet, GoldWorth = 25, Strength = 4, Agility = 7, Intelligence = 9 },
                new Equipment { Id = 5, Name = "Lord of the Ring", Type = EquipmentType.Ring, GoldWorth = 22, Strength = 6, Agility = 5, Intelligence = 8 },
                new Equipment { Id = 6, Name = "Pearl Necklace", Type = EquipmentType.Necklace, GoldWorth = 15, Strength = 7, Agility = 3, Intelligence = 4 },
                new Equipment { Id = 7, Name = "Iron Sword", Type = EquipmentType.Hand, GoldWorth = 28, Strength = 16, Agility = 6, Intelligence = 3 },
                new Equipment { Id = 8, Name = "Iron Helmet", Type = EquipmentType.Head, GoldWorth = 32, Strength = 9, Agility = 4, Intelligence = 2 },
                new Equipment { Id = 9, Name = "Iron Chestplate", Type = EquipmentType.Chest, GoldWorth = 45, Strength = 13, Agility = 7, Intelligence = 4 },
                new Equipment { Id = 10, Name = "Iron Boots", Type = EquipmentType.Feet, GoldWorth = 27, Strength = 5, Agility = 8, Intelligence = 10 },
                new Equipment { Id = 11, Name = "Speed Ring", Type = EquipmentType.Ring, GoldWorth = 18, Strength = 4, Agility = 9, Intelligence = 5 },
                new Equipment { Id = 12, Name = "Diamond Necklace", Type = EquipmentType.Necklace, GoldWorth = 12, Strength = 6, Agility = 4, Intelligence = 3 },
                new Equipment { Id = 13, Name = "Wooden Sword", Type = EquipmentType.Hand, GoldWorth = 14, Strength = 14, Agility = 6, Intelligence = 2 },
                new Equipment { Id = 14, Name = "Wooden Helmet", Type = EquipmentType.Head, GoldWorth = 26, Strength = 6, Agility = 4, Intelligence = 2 },
                new Equipment { Id = 15, Name = "Wooden Chestplate", Type = EquipmentType.Chest, GoldWorth = 42, Strength = 11, Agility = 6, Intelligence = 3 },
                new Equipment { Id = 16, Name = "Wooden Boots", Type = EquipmentType.Feet, GoldWorth = 24, Strength = 3, Agility = 8, Intelligence = 7 },
                new Equipment { Id = 17, Name = "Strength Ring", Type = EquipmentType.Ring, GoldWorth = 17, Strength = 10, Agility = 5, Intelligence = 6 },
                new Equipment { Id = 18, Name = "Agility Necklace", Type = EquipmentType.Necklace, GoldWorth = 11, Strength = 5, Agility = 10, Intelligence = 2 }
            );

            modelBuilder.Entity<NinjaEquipment>().HasData(
                new NinjaEquipment { NinjaId = 1, EquipmentId = 1 },
                new NinjaEquipment { NinjaId = 2, EquipmentId = 2 }
            );
        }
    }
}