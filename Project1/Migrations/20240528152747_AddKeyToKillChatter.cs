using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyToKillChatter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Kill_Chatter",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "KillChatterID",
                table: "General_Chatter",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kill_Chatter",
                table: "Kill_Chatter",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_General_Chatter_KillChatterID",
                table: "General_Chatter",
                column: "KillChatterID");

            migrationBuilder.AddForeignKey(
                name: "FK_General_Chatter_Kill_Chatter_KillChatterID",
                table: "General_Chatter",
                column: "KillChatterID",
                principalTable: "Kill_Chatter",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_General_Chatter_Kill_Chatter_KillChatterID",
                table: "General_Chatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kill_Chatter",
                table: "Kill_Chatter");

            migrationBuilder.DropIndex(
                name: "IX_General_Chatter_KillChatterID",
                table: "General_Chatter");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Kill_Chatter");

            migrationBuilder.DropColumn(
                name: "KillChatterID",
                table: "General_Chatter");
        }
    }
}
