using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToChatBoxes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kill_Chatter_InnChatter_ID",
                table: "Kill_Chatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kill_Chatter",
                table: "Kill_Chatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InnChatter",
                table: "InnChatter");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Kill_Chatter");

            migrationBuilder.RenameTable(
                name: "InnChatter",
                newName: "General_Chatter");

            migrationBuilder.RenameColumn(
                name: "messages",
                table: "General_Chatter",
                newName: "message");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Game_Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_General_Chatter",
                table: "General_Chatter",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_General_Chatter",
                table: "General_Chatter");

            migrationBuilder.RenameTable(
                name: "General_Chatter",
                newName: "InnChatter");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "InnChatter",
                newName: "messages");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Kill_Chatter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Game_Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kill_Chatter",
                table: "Kill_Chatter",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InnChatter",
                table: "InnChatter",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kill_Chatter_InnChatter_ID",
                table: "Kill_Chatter",
                column: "ID",
                principalTable: "InnChatter",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
