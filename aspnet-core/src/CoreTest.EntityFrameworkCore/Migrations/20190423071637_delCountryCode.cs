using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class delCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_CustomerFile_CountryCode_CustomerBrandId",
                table: "CRM_CustomerFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_CustomerContact_CountryCode_CustomerContactId",
                table: "CRM_CustomerContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerContact",
                table: "CRM_CustomerContact");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_CustomerBrand_CountryCode_CustomerBrandId",
                table: "CRM_CustomerBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerBrand",
                table: "CRM_CustomerBrand");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_Customer_CountryCode_CustomerId",
                table: "CRM_Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_Customer",
                table: "CRM_Customer");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CRM_Brand_CountryCode_BrandId",
                table: "CRM_Brand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_Brand",
                table: "CRM_Brand");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CRM_CustomerFile");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CRM_CustomerContact");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CRM_CustomerBrand");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CRM_Customer");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CRM_Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile",
                column: "CustomerBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerContact",
                table: "CRM_CustomerContact",
                column: "CustomerContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerBrand",
                table: "CRM_CustomerBrand",
                column: "CustomerBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_Customer",
                table: "CRM_Customer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_Brand",
                table: "CRM_Brand",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerContact",
                table: "CRM_CustomerContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_CustomerBrand",
                table: "CRM_CustomerBrand");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_Customer",
                table: "CRM_Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CRM_Brand",
                table: "CRM_Brand");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CRM_CustomerFile",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CRM_CustomerContact",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CRM_CustomerBrand",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CRM_Customer",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CRM_Brand",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_CustomerFile_CountryCode_CustomerBrandId",
                table: "CRM_CustomerFile",
                columns: new[] { "CountryCode", "CustomerBrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerFile",
                table: "CRM_CustomerFile",
                columns: new[] { "CustomerBrandId", "CountryCode" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_CustomerContact_CountryCode_CustomerContactId",
                table: "CRM_CustomerContact",
                columns: new[] { "CountryCode", "CustomerContactId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerContact",
                table: "CRM_CustomerContact",
                columns: new[] { "CustomerContactId", "CountryCode" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_CustomerBrand_CountryCode_CustomerBrandId",
                table: "CRM_CustomerBrand",
                columns: new[] { "CountryCode", "CustomerBrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_CustomerBrand",
                table: "CRM_CustomerBrand",
                columns: new[] { "CustomerBrandId", "CountryCode" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_Customer_CountryCode_CustomerId",
                table: "CRM_Customer",
                columns: new[] { "CountryCode", "CustomerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_Customer",
                table: "CRM_Customer",
                columns: new[] { "CustomerId", "CountryCode" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CRM_Brand_CountryCode_BrandId",
                table: "CRM_Brand",
                columns: new[] { "CountryCode", "BrandId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CRM_Brand",
                table: "CRM_Brand",
                columns: new[] { "BrandId", "CountryCode" });
        }
    }
}
