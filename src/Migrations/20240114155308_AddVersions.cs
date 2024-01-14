using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aiursoft.WingetCommunityServer.Migrations
{
    /// <inheritdoc />
    public partial class AddVersions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageVersions",
                columns: table => new
                {
                    DatabaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    InstallerType = table.Column<string>(type: "TEXT", nullable: false),
                    Scope = table.Column<string>(type: "TEXT", nullable: false),
                    InstallModes = table.Column<string>(type: "TEXT", nullable: false),
                    InstallerSwitches = table.Column<string>(type: "TEXT", nullable: false),
                    InstallerSuccessCodes = table.Column<string>(type: "TEXT", nullable: false),
                    UpgradeBehavior = table.Column<string>(type: "TEXT", nullable: false),
                    Protocols = table.Column<string>(type: "TEXT", nullable: false),
                    FileExtensions = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageVersions", x => x.DatabaseId);
                    table.ForeignKey(
                        name: "FK_PackageVersions_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "DatabaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageVersionInstallers",
                columns: table => new
                {
                    DatabaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageVersionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Architecture = table.Column<string>(type: "TEXT", nullable: false),
                    InstallerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    InstallerSha256 = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageVersionInstallers", x => x.DatabaseId);
                    table.ForeignKey(
                        name: "FK_PackageVersionInstallers_PackageVersions_PackageVersionId",
                        column: x => x.PackageVersionId,
                        principalTable: "PackageVersions",
                        principalColumn: "DatabaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageVersionLocales",
                columns: table => new
                {
                    DatabaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackageVersionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PackageLocale = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    PublisherUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PublisherSupportUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PrivacyUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    PackageName = table.Column<string>(type: "TEXT", nullable: true),
                    PackageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    License = table.Column<string>(type: "TEXT", nullable: true),
                    LicenseUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CopyRight = table.Column<string>(type: "TEXT", nullable: true),
                    CopyRightUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Tags = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseNotes = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseNotesUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PurchaseUrl = table.Column<string>(type: "TEXT", nullable: true),
                    InstallationNotes = table.Column<string>(type: "TEXT", nullable: true),
                    Documentations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageVersionLocales", x => x.DatabaseId);
                    table.ForeignKey(
                        name: "FK_PackageVersionLocales_PackageVersions_PackageVersionId",
                        column: x => x.PackageVersionId,
                        principalTable: "PackageVersions",
                        principalColumn: "DatabaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageVersionInstallers_PackageVersionId",
                table: "PackageVersionInstallers",
                column: "PackageVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageVersionLocales_PackageVersionId",
                table: "PackageVersionLocales",
                column: "PackageVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageVersions_PackageId",
                table: "PackageVersions",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageVersionInstallers");

            migrationBuilder.DropTable(
                name: "PackageVersionLocales");

            migrationBuilder.DropTable(
                name: "PackageVersions");
        }
    }
}
