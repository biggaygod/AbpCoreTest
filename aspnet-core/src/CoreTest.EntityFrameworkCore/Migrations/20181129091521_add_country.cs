using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class add_country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CountryName = table.Column<string>(maxLength: 120, nullable: true),
                    CountryShort = table.Column<string>(maxLength: 120, nullable: true),
                    ChineseName = table.Column<string>(maxLength: 120, nullable: true),
                    EnglishName = table.Column<string>(maxLength: 120, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Country", x => new { x.Id, x.CountryCode });
                    table.UniqueConstraint("AK_C_Country_CountryCode", x => x.CountryCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C_Country");
        }
    }
}
