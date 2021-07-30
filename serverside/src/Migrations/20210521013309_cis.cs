using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis.Migrations
{
    public partial class cis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Name",
                table: "RegionalArea");

            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Sa2code",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Sa2code",
                table: "RegionalArea");

            migrationBuilder.RenameColumn(
                name: "Pph",
                table: "RegionalArea",
                newName: "Numofpph");

            migrationBuilder.RenameColumn(
                name: "Nonindigenouspopulation",
                table: "RegionalArea",
                newName: "Nonindigenous");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegionalArea",
                newName: "Sa3id");

            migrationBuilder.RenameColumn(
                name: "Indigenouspopulation",
                table: "RegionalArea",
                newName: "Indigenous");

            migrationBuilder.AddColumn<double>(
                name: "Percentpphperday",
                table: "RegionalArea",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sa2id",
                table: "RegionalArea",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sa2name",
                table: "RegionalArea",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sa3name",
                table: "RegionalArea",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Sa2id",
                table: "RegionalArea",
                column: "Sa2id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Sa2name",
                table: "RegionalArea",
                column: "Sa2name");

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Sa3id",
                table: "RegionalArea",
                column: "Sa3id");

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Sa3name",
                table: "RegionalArea",
                column: "Sa3name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Sa2id",
                table: "RegionalArea");

            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Sa2name",
                table: "RegionalArea");

            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Sa3id",
                table: "RegionalArea");

            migrationBuilder.DropIndex(
                name: "IX_RegionalArea_Sa3name",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Percentpphperday",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Sa2id",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Sa2name",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Sa3name",
                table: "RegionalArea");

            migrationBuilder.RenameColumn(
                name: "Sa3id",
                table: "RegionalArea",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Numofpph",
                table: "RegionalArea",
                newName: "Pph");

            migrationBuilder.RenameColumn(
                name: "Nonindigenous",
                table: "RegionalArea",
                newName: "Nonindigenouspopulation");

            migrationBuilder.RenameColumn(
                name: "Indigenous",
                table: "RegionalArea",
                newName: "Indigenouspopulation");

            migrationBuilder.AddColumn<int>(
                name: "Sa2code",
                table: "RegionalArea",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Name",
                table: "RegionalArea",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegionalArea_Sa2code",
                table: "RegionalArea",
                column: "Sa2code",
                unique: true);
        }
    }
}
