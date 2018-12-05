using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class change_fileTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_File_CountryCode_CustomerBrandId",
                table: "CRM_File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_File",
                table: "CRM_File");

            migrationBuilder.RenameTable(
                name: "CRM_File",
                newName: "CRM_CustomerFile");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_CustomerFile_CountryCode_CustomerBrandId",
                table: "CRM_CustomerFile",
                columns: new[] { "CountryCode", "CustomerBrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile",
                columns: new[] { "CustomerBrandId", "CountryCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_CustomerFile_CountryCode_CustomerBrandId",
                table: "CRM_CustomerFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile");

            migrationBuilder.RenameTable(
                name: "CRM_CustomerFile",
                newName: "CRM_File");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_File_CountryCode_CustomerBrandId",
                table: "CRM_File",
                columns: new[] { "CountryCode", "CustomerBrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_File",
                table: "CRM_File",
                columns: new[] { "CustomerBrandId", "CountryCode" });
        }
    }
}
