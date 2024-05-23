using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game_Items",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemBaseValue = table.Column<int>(type: "int", nullable: false),
                    QuantityOfItem = table.Column<int>(type: "int", nullable: false),
                    buyLvlRequirement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "InnChatter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnChatter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Level_Progression",
                columns: table => new
                {
                    LevelNum = table.Column<int>(type: "int", nullable: false),
                    XPRequiredForLevel = table.Column<int>(type: "int", nullable: false),
                    MaxHitPointIncrease = table.Column<int>(type: "int", nullable: false), 
                    StrengthIncrease = table.Column<int>(type: "int", nullable: false),
                    DexterityIncrease = table.Column<int>(type: "int", nullable: false),
                    ConstitutionIncrease = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level_Progression", x => x.LevelNum);
                });

            migrationBuilder.CreateTable(
                name: "Game_Armors",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MitigationIncrease = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Armors", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Game_Armors_Game_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Game_Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game_Potions",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HPRestoration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Potions", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Game_Potions_Game_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Game_Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game_Weapons",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttackIncrease = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Weapons", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Game_Weapons_Game_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Game_Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kill_Chatter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    monsterType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kill_Chatter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kill_Chatter_InnChatter_ID",
                        column: x => x.ID,
                        principalTable: "InnChatter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerLevel = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    EquippedWeaponID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EquippedArmorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerXP = table.Column<int>(type: "int", nullable: false),
                    CurrentLocation = table.Column<int>(type: "int", nullable: false),
                    PlayerGold = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHitPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Game_Armors_EquippedArmorID",
                        column: x => x.EquippedArmorID,
                        principalTable: "Game_Armors",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Game_Weapons_EquippedWeaponID",
                        column: x => x.EquippedWeaponID,
                        principalTable: "Game_Weapons",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExploredLocation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationHash = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExploredLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExploredLocation_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Inventory_Armors",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    playerQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Inventory_Armors", x => new { x.PlayerID, x.ArmorID });
                    table.ForeignKey(
                        name: "FK_Player_Inventory_Armors_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Inventory_Items",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    playerQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Inventory_Items", x => new { x.PlayerID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_Player_Inventory_Items_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Inventory_Potions",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PotionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    playerQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Inventory_Potions", x => new { x.PlayerID, x.PotionID });
                    table.ForeignKey(
                        name: "FK_Player_Inventory_Potions_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Inventory_Weapons",
                columns: table => new
                {
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeaponID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    playerQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Inventory_Weapons", x => new { x.PlayerID, x.WeaponID });
                    table.ForeignKey(
                        name: "FK_Player_Inventory_Weapons_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapLineOrder = table.Column<int>(type: "int", nullable: false),
                    MapLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerMap_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExploredLocation_PlayerID",
                table: "ExploredLocation",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMap_PlayerID",
                table: "PlayerMap",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_EquippedArmorID",
                table: "Players",
                column: "EquippedArmorID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_EquippedWeaponID",
                table: "Players",
                column: "EquippedWeaponID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExploredLocation");

            migrationBuilder.DropTable(
                name: "Game_Potions");

            migrationBuilder.DropTable(
                name: "Kill_Chatter");

            migrationBuilder.DropTable(
                name: "Level_Progression");

            migrationBuilder.DropTable(
                name: "Player_Inventory_Armors");

            migrationBuilder.DropTable(
                name: "Player_Inventory_Items");

            migrationBuilder.DropTable(
                name: "Player_Inventory_Potions");

            migrationBuilder.DropTable(
                name: "Player_Inventory_Weapons");

            migrationBuilder.DropTable(
                name: "PlayerMap");

            migrationBuilder.DropTable(
                name: "InnChatter");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Game_Armors");

            migrationBuilder.DropTable(
                name: "Game_Weapons");

            migrationBuilder.DropTable(
                name: "Game_Items");
        }
    }
}
