﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project1.Data;

#nullable disable

namespace Project1.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20240528152747_AddKeyToKillChatter")]
    partial class AddKeyToKillChatter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project1.Models.ExploredLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("locationHash")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("ExploredLocation");
                });

            modelBuilder.Entity("Project1.Models.GeneralChatter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("KillChatterID")
                        .HasColumnType("int");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KillChatterID");

                    b.ToTable("General_Chatter");
                });

            modelBuilder.Entity("Project1.Models.Item", b =>
                {
                    b.Property<string>("ItemID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ItemBaseValue")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOfItem")
                        .HasColumnType("int");

                    b.Property<int>("buyLvlRequirement")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.ToTable("Game_Items");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Project1.Models.KillChatter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("monsterType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Kill_Chatter");
                });

            modelBuilder.Entity("Project1.Models.LevelChange", b =>
                {
                    b.Property<int>("LevelNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LevelNum"));

                    b.Property<int>("ConstitutionIncrease")
                        .HasColumnType("int");

                    b.Property<int>("DexterityIncrease")
                        .HasColumnType("int");

                    b.Property<int>("MaxHitPointIncrease")
                        .HasColumnType("int");

                    b.Property<int>("StrengthIncrease")
                        .HasColumnType("int");

                    b.Property<int>("XPRequiredForLevel")
                        .HasColumnType("int");

                    b.HasKey("LevelNum");

                    b.ToTable("Level_Progression");
                });

            modelBuilder.Entity("Project1.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHitPoints")
                        .HasColumnType("int");

                    b.Property<int>("CurrentLocation")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<string>("EquippedArmorID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EquippedWeaponID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaxHitPoints")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerGold")
                        .HasColumnType("int");

                    b.Property<int>("PlayerLevel")
                        .HasColumnType("int");

                    b.Property<int>("PlayerXP")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("EquippedArmorID");

                    b.HasIndex("EquippedWeaponID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryArmor", b =>
                {
                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArmorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("playerQuantity")
                        .HasColumnType("int");

                    b.HasKey("PlayerID", "ArmorID");

                    b.ToTable("Player_Inventory_Armors");
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryItem", b =>
                {
                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("playerQuantity")
                        .HasColumnType("int");

                    b.HasKey("PlayerID", "ItemID");

                    b.ToTable("Player_Inventory_Items");
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryPotion", b =>
                {
                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PotionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("playerQuantity")
                        .HasColumnType("int");

                    b.HasKey("PlayerID", "PotionID");

                    b.ToTable("Player_Inventory_Potions");
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryWeapon", b =>
                {
                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WeaponID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("playerQuantity")
                        .HasColumnType("int");

                    b.HasKey("PlayerID", "WeaponID");

                    b.ToTable("Player_Inventory_Weapons");
                });

            modelBuilder.Entity("Project1.Models.PlayerMap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("MapLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MapLineOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayerMap");
                });

            modelBuilder.Entity("Project1.Models.Armor", b =>
                {
                    b.HasBaseType("Project1.Models.Item");

                    b.Property<int>("MitigationIncrease")
                        .HasColumnType("int");

                    b.ToTable("Game_Armors");
                });

            modelBuilder.Entity("Project1.Models.Potion", b =>
                {
                    b.HasBaseType("Project1.Models.Item");

                    b.Property<int>("HPRestoration")
                        .HasColumnType("int");

                    b.ToTable("Game_Potions");
                });

            modelBuilder.Entity("Project1.Models.Weapon", b =>
                {
                    b.HasBaseType("Project1.Models.Item");

                    b.Property<int>("AttackIncrease")
                        .HasColumnType("int");

                    b.ToTable("Game_Weapons");
                });

            modelBuilder.Entity("Project1.Models.ExploredLocation", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("ExploredLocations")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.GeneralChatter", b =>
                {
                    b.HasOne("Project1.Models.KillChatter", null)
                        .WithMany("messages")
                        .HasForeignKey("KillChatterID");
                });

            modelBuilder.Entity("Project1.Models.Player", b =>
                {
                    b.HasOne("Project1.Models.Armor", "EquippedArmor")
                        .WithMany()
                        .HasForeignKey("EquippedArmorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Project1.Models.Weapon", "EquippedWeapon")
                        .WithMany()
                        .HasForeignKey("EquippedWeaponID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EquippedArmor");

                    b.Navigation("EquippedWeapon");
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryArmor", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("InventoryArmors")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryItem", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("InventoryItems")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryPotion", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("InventoryPotions")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.PlayerInventoryWeapon", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("InventoryWeapons")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.PlayerMap", b =>
                {
                    b.HasOne("Project1.Models.Player", null)
                        .WithMany("PlayerMap")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.Armor", b =>
                {
                    b.HasOne("Project1.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Project1.Models.Armor", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.Potion", b =>
                {
                    b.HasOne("Project1.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Project1.Models.Potion", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.Weapon", b =>
                {
                    b.HasOne("Project1.Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Project1.Models.Weapon", "ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.KillChatter", b =>
                {
                    b.Navigation("messages");
                });

            modelBuilder.Entity("Project1.Models.Player", b =>
                {
                    b.Navigation("ExploredLocations");

                    b.Navigation("InventoryArmors");

                    b.Navigation("InventoryItems");

                    b.Navigation("InventoryPotions");

                    b.Navigation("InventoryWeapons");

                    b.Navigation("PlayerMap");
                });
#pragma warning restore 612, 618
        }
    }
}
