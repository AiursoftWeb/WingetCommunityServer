using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aiursoft.WingetCommunityServer.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "PackageVersions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Moniker",
                table: "PackageVersionLocales",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "PackageVersions");

            migrationBuilder.DropColumn(
                name: "Moniker",
                table: "PackageVersionLocales");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Packages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Packages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Packages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
