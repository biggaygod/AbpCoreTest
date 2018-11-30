using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class del_country2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C_Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C_Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    ChineseName = table.Column<string>(maxLength: 120, nullable: true),
                    CountryName = table.Column<string>(maxLength: 120, nullable: true),
                    CountryShort = table.Column<string>(maxLength: 120, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EnglishName = table.Column<string>(maxLength: 120, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Country", x => new { x.Id, x.CountryCode });
                    table.UniqueConstraint("AK_C_Country_CountryCode", x => x.CountryCode);
                });
        }
    }
}
