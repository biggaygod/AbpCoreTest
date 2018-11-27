using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTest.Migrations
{
    public partial class add_BaseData_CustomerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base_City",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CityCode = table.Column<string>(maxLength: 10, nullable: true),
                    CityName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    CityType = table.Column<int>(nullable: true),
                    CityLevel = table.Column<int>(nullable: true),
                    Spell = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    IsSales = table.Column<bool>(nullable: false),
                    IsFinance = table.Column<bool>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_City", x => new { x.CityId, x.CountryCode });
                    table.UniqueConstraint("AK_Base_City_CountryCode_CityId", x => new { x.CountryCode, x.CityId });
                });

            migrationBuilder.CreateTable(
                name: "Base_SignBody",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BodyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    BodyCode = table.Column<string>(maxLength: 20, nullable: true),
                    BodyName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_SignBody", x => new { x.BodyId, x.CountryCode });
                    table.UniqueConstraint("AK_Base_SignBody_CountryCode_BodyId", x => new { x.CountryCode, x.BodyId });
                });

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

            migrationBuilder.CreateTable(
                name: "CRM_Brand",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    BrandName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    Spell = table.Column<string>(maxLength: 20, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_Brand", x => new { x.BrandId, x.CountryCode });
                    table.UniqueConstraint("AK_CRM_Brand_CountryCode_BrandId", x => new { x.CountryCode, x.BrandId });
                });

            migrationBuilder.CreateTable(
                name: "CRM_Customer",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    Spell = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    Phone = table.Column<string>(maxLength: 120, nullable: true),
                    SyncId = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_Customer", x => new { x.CustomerId, x.CountryCode });
                    table.UniqueConstraint("AK_CRM_Customer_CountryCode_CustomerId", x => new { x.CountryCode, x.CustomerId });
                });

            migrationBuilder.CreateTable(
                name: "CRM_CustomerBrand",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CustomerBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_CustomerBrand", x => new { x.CustomerBrandId, x.CountryCode });
                    table.UniqueConstraint("AK_CRM_CustomerBrand_CountryCode_CustomerBrandId", x => new { x.CountryCode, x.CustomerBrandId });
                });

            migrationBuilder.CreateTable(
                name: "CRM_CustomerContact",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CustomerContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    Position = table.Column<string>(maxLength: 120, nullable: true),
                    TelePhone = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 120, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_CustomerContact", x => new { x.CustomerContactId, x.CountryCode });
                    table.UniqueConstraint("AK_CRM_CustomerContact_CountryCode_CustomerContactId", x => new { x.CountryCode, x.CustomerContactId });
                });

            migrationBuilder.CreateTable(
                name: "CRM_File",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CustomerBrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(maxLength: 1000, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_File", x => new { x.CustomerBrandId, x.CountryCode });
                    table.UniqueConstraint("AK_CRM_File_CountryCode_CustomerBrandId", x => new { x.CountryCode, x.CustomerBrandId });
                });

            migrationBuilder.CreateTable(
                name: "Dic_Dictionary",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DicName = table.Column<string>(maxLength: 120, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dic_Dictionary", x => x.DicId);
                });

            migrationBuilder.CreateTable(
                name: "ED_Department",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    DeptCode = table.Column<string>(maxLength: 20, nullable: true),
                    DeptName = table.Column<string>(maxLength: 120, nullable: true),
                    ParentDeptId = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ED_Department", x => new { x.DeptId, x.CountryCode });
                    table.UniqueConstraint("AK_ED_Department_CountryCode_DeptId", x => new { x.CountryCode, x.DeptId });
                });

            migrationBuilder.CreateTable(
                name: "ED_Employee",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    ECode = table.Column<string>(maxLength: 20, nullable: true),
                    EName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    DeptId = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ED_Employee", x => new { x.EId, x.CountryCode });
                    table.UniqueConstraint("AK_ED_Employee_CountryCode_EId", x => new { x.CountryCode, x.EId });
                });

            migrationBuilder.CreateTable(
                name: "PayType",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    CountryCode = table.Column<string>(maxLength: 20, nullable: false),
                    PayCode = table.Column<int>(nullable: false),
                    PayName = table.Column<string>(maxLength: 120, nullable: true),
                    EngName = table.Column<string>(maxLength: 120, nullable: true),
                    CN_Code = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayType", x => new { x.Id, x.CountryCode });
                    table.UniqueConstraint("AK_PayType_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dic_DictionaryDetail",
                columns: table => new
                {
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DicId = table.Column<int>(nullable: false),
                    NameLCode = table.Column<string>(maxLength: 120, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dic_DictionaryDetail", x => x.DId);
                    table.ForeignKey(
                        name: "FK_Dic_DictionaryDetail_Dic_Dictionary_DicId",
                        column: x => x.DicId,
                        principalTable: "Dic_Dictionary",
                        principalColumn: "DicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dic_DictionaryDetail_DicId",
                table: "Dic_DictionaryDetail",
                column: "DicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Base_City");

            migrationBuilder.DropTable(
                name: "Base_SignBody");

            migrationBuilder.DropTable(
                name: "C_Country");

            migrationBuilder.DropTable(
                name: "CRM_Brand");

            migrationBuilder.DropTable(
                name: "CRM_Customer");

            migrationBuilder.DropTable(
                name: "CRM_CustomerBrand");

            migrationBuilder.DropTable(
                name: "CRM_CustomerContact");

            migrationBuilder.DropTable(
                name: "CRM_File");

            migrationBuilder.DropTable(
                name: "Dic_DictionaryDetail");

            migrationBuilder.DropTable(
                name: "ED_Department");

            migrationBuilder.DropTable(
                name: "ED_Employee");

            migrationBuilder.DropTable(
                name: "PayType");

            migrationBuilder.DropTable(
                name: "Dic_Dictionary");
        }
    }
}
