using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class del_Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CRM_Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRM_Brand",
                columns: table => new
                {
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    BrandName = table.Column<string>(maxLength: 120, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Spell = table.Column<string>(maxLength: 20, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_Brand", x => x.CountryCode);
                });
        }
    }
}
