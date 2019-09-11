using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClearanceReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearanceReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EligibleNID",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashedNID = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleNID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForeignContractorType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignContractorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForeignContractType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentalEstablishmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentalEstablishmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PostDeliveryDays = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issuer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PackageExpiryInHours = table.Column<int>(nullable: false),
                    PackageDescription = table.Column<string>(maxLength: 500, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    ReplyPeriod = table.Column<int>(nullable: false),
                    HomePageUrl = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeNID",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeNID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypeWorkPermit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypeWorkPermit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ministry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NidIssueReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NidIssueReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassportIssuer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportIssuer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RejectionReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectionReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestEFinance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<string>(maxLength: 50, nullable: true),
                    SenderName = table.Column<string>(maxLength: 50, nullable: true),
                    SenderRandomValue = table.Column<string>(maxLength: 100, nullable: true),
                    SenderPassword = table.Column<string>(maxLength: 100, nullable: true),
                    SenderRequestNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentRequestNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentRequestTotalAmount = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: true),
                    CollectionFeesAmount = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: true),
                    CustomerAuthorizationAmount = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: true),
                    AuthorizingMechanism = table.Column<string>(maxLength: 20, nullable: true),
                    AuthoriztionDateTime = table.Column<DateTime>(nullable: true),
                    ReconciliationDate = table.Column<DateTime>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestEFinance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestPostal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(maxLength: 100, nullable: false),
                    ItemCode = table.Column<string>(maxLength: 20, nullable: false),
                    ErrorCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPostal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermitIssueReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermitIssueReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentalEstablishment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    GovernmentalEstablishmentTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentalEstablishment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernmentalEstablishment_GovernmentalEstablishmentType_GovernmentalEstablishmentTypeId",
                        column: x => x.GovernmentalEstablishmentTypeId,
                        principalTable: "GovernmentalEstablishmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliceDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    GovernorateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceDepartment_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    GovernorateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    MaxCopies = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: false),
                    MaxBeneficiaries = table.Column<int>(nullable: false),
                    CanBeBundled = table.Column<bool>(nullable: false),
                    IsInstantApproval = table.Column<bool>(nullable: false),
                    Agreement = table.Column<string>(nullable: false),
                    IssuerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentType_Issuer_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Issuer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestFawry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FawryRefNo = table.Column<string>(maxLength: 20, nullable: true),
                    FawryPaymentMethod = table.Column<string>(maxLength: 20, nullable: true),
                    OrderStatusId = table.Column<int>(nullable: true),
                    OrderAmount = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: true),
                    MessageSignature = table.Column<string>(maxLength: 64, nullable: true),
                    Notes = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFawry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestFawry_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    QualificationTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualification_QualificationType_QualificationTypeId",
                        column: x => x.QualificationTypeId,
                        principalTable: "QualificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicSector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GovernmentalEstablishmentId = table.Column<int>(nullable: true),
                    VacationTypeId = table.Column<int>(nullable: false),
                    VacationStart = table.Column<DateTime>(nullable: false),
                    VacationEnd = table.Column<DateTime>(nullable: false),
                    VacationApprovedYears = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicSector_GovernmentalEstablishment_GovernmentalEstablishmentId",
                        column: x => x.GovernmentalEstablishmentId,
                        principalTable: "GovernmentalEstablishment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicSector_VacationType_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostalCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    PoliceDepartmentId = table.Column<int>(nullable: true),
                    GovernorateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalCode_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostalCode_PoliceDepartment_PoliceDepartmentId",
                        column: x => x.PoliceDepartmentId,
                        principalTable: "PoliceDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypeRelations",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false),
                    RelationId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypeRelations", x => new { x.DocumentTypeId, x.RelationId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_DocumentTypeRelations_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTypeRelations_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTypeRelations_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regulations",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false),
                    JobTypeNIDId = table.Column<int>(nullable: false),
                    Regulations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulations", x => new { x.DocumentTypeId, x.JobTypeNIDId });
                    table.ForeignKey(
                        name: "FK_Regulations_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regulations_JobTypeNID_JobTypeNIDId",
                        column: x => x.JobTypeNIDId,
                        principalTable: "JobTypeNID",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignContractor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorCountryId = table.Column<int>(nullable: false),
                    ContractorName = table.Column<string>(maxLength: 100, nullable: false),
                    ContractorTypeId = table.Column<int>(nullable: false),
                    ContractorActivity = table.Column<string>(maxLength: 100, nullable: false),
                    ContractorJobName = table.Column<string>(maxLength: 100, nullable: false),
                    ContractTypeId = table.Column<int>(nullable: false),
                    YearsToRenew = table.Column<int>(nullable: false),
                    WorkPlaceIsOnShips = table.Column<bool>(nullable: false),
                    VisaNoOrAccomodationNo = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: false),
                    AddressCountryId = table.Column<int>(nullable: false),
                    AddressCity = table.Column<string>(maxLength: 100, nullable: false),
                    AddressDistrict = table.Column<string>(maxLength: 100, nullable: false),
                    AddressStreet = table.Column<string>(maxLength: 100, nullable: false),
                    AddressBuilding = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignContractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignContractor_Country_AddressCountryId",
                        column: x => x.AddressCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignContractor_ForeignContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ForeignContractType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignContractor_Country_ContractorCountryId",
                        column: x => x.ContractorCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignContractor_ForeignContractorType_ContractorTypeId",
                        column: x => x.ContractorTypeId,
                        principalTable: "ForeignContractorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForeignContractor_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassportNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PassportIssueDate = table.Column<DateTime>(nullable: false),
                    PassportIssueCountryId = table.Column<int>(nullable: false),
                    JobInPassportId = table.Column<int>(nullable: false),
                    LastLeaveDate = table.Column<DateTime>(nullable: false),
                    LastReturnDate = table.Column<DateTime>(nullable: false),
                    PassportIssuerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passport_Job_JobInPassportId",
                        column: x => x.JobInPassportId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passport_Country_PassportIssueCountryId",
                        column: x => x.PassportIssueCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passport_PassportIssuer_PassportIssuerId",
                        column: x => x.PassportIssuerId,
                        principalTable: "PassportIssuer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlatNumber = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    BuildingNumber = table.Column<string>(maxLength: 20, nullable: false),
                    StreetName = table.Column<string>(maxLength: 50, nullable: false),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: false),
                    GovernorateId = table.Column<int>(nullable: false),
                    PoliceDepartmentId = table.Column<int>(nullable: false),
                    PostalCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_PoliceDepartment_PoliceDepartmentId",
                        column: x => x.PoliceDepartmentId,
                        principalTable: "PoliceDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_PostalCode_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalTable: "PostalCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    MotherFullName = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    NID = table.Column<string>(maxLength: 14, nullable: false),
                    ContactDetails_Mobile1 = table.Column<string>(maxLength: 20, nullable: false),
                    ContactDetails_Mobile2 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactDetails_PhoneHome = table.Column<string>(maxLength: 20, nullable: true),
                    ContactDetails_PhoneWork = table.Column<string>(maxLength: 20, nullable: true),
                    ContactDetails_Email = table.Column<string>(maxLength: 50, nullable: false),
                    ResidencyAddressId = table.Column<int>(nullable: false),
                    DeliveryAddressId = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    IssuerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Address_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Issuer_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Issuer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Address_ResidencyAddressId",
                        column: x => x.ResidencyAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BirthDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false, defaultValue: 1),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    NID = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    MotherFullName = table.Column<string>(maxLength: 100, nullable: false),
                    RelationId = table.Column<int>(nullable: false),
                    IsFirstTime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthDocs_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthDocs_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthDocs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirthDocs_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CriminalStateRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    IssueDestination = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalStateRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriminalStateRecords_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CriminalStateRecords_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeathDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false, defaultValue: 1),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    NID = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    MotherFullName = table.Column<string>(maxLength: 100, nullable: false),
                    RelationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeathDocs_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeathDocs_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeathDocs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeathDocs_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivorceDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false, defaultValue: 1),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    NID = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    SpouseFullName = table.Column<string>(maxLength: 100, nullable: false),
                    RelationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivorceDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivorceDocs_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivorceDocs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DivorceDocs_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    NID = table.Column<string>(maxLength: 14, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    MotherFullName = table.Column<string>(maxLength: 100, nullable: false),
                    RelationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyRecords_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyRecords_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyRecords_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyRecords_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarriageDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false, defaultValue: 1),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    NID = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false),
                    SpouseFullName = table.Column<string>(maxLength: 100, nullable: false),
                    RelationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarriageDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarriageDocs_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarriageDocs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarriageDocs_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NidDocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false, defaultValue: 1),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(maxLength: 20, nullable: false),
                    GrandFatherName = table.Column<string>(maxLength: 20, nullable: false),
                    FamilyName = table.Column<string>(maxLength: 20, nullable: false),
                    NidIssueReasonId = table.Column<int>(nullable: false),
                    JobTypeNIDId = table.Column<int>(nullable: false),
                    JobName = table.Column<string>(maxLength: 100, nullable: false),
                    IsFirstTime = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NidDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NidDocs_JobTypeNID_JobTypeNIDId",
                        column: x => x.JobTypeNIDId,
                        principalTable: "JobTypeNID",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NidDocs_NidIssueReason_NidIssueReasonId",
                        column: x => x.NidIssueReasonId,
                        principalTable: "NidIssueReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NidDocs_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NidDocs_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(15, 5)", nullable: false),
                    Notes = table.Column<string>(maxLength: 500, nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalRecords_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalRecords_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    RejectionReasonId = table.Column<int>(nullable: true),
                    ReturnReasonId = table.Column<int>(nullable: true),
                    RequestFawryId = table.Column<int>(nullable: true),
                    RequestEFinanceId = table.Column<int>(nullable: true),
                    RequestPostalId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestState_RejectionReason_RejectionReasonId",
                        column: x => x.RejectionReasonId,
                        principalTable: "RejectionReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_RequestEFinance_RequestEFinanceId",
                        column: x => x.RequestEFinanceId,
                        principalTable: "RequestEFinance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_RequestFawry_RequestFawryId",
                        column: x => x.RequestFawryId,
                        principalTable: "RequestFawry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_RequestPostal_RequestPostalId",
                        column: x => x.RequestPostalId,
                        principalTable: "RequestPostal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_ReturnReason_ReturnReasonId",
                        column: x => x.ReturnReasonId,
                        principalTable: "ReturnReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestState_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermitClearanceaa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    PassportId = table.Column<int>(nullable: false),
                    LastPermitFinishDate = table.Column<DateTime>(nullable: false),
                    ClearanceDestination = table.Column<string>(maxLength: 100, nullable: false),
                    ClearanceReasonId = table.Column<int>(nullable: false),
                    NidFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PassportFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PreviousPermitFileName = table.Column<string>(maxLength: 100, nullable: false),
                    VisaFileName = table.Column<string>(maxLength: 100, nullable: false),
                    RenewDirectedLetterFileName = table.Column<string>(maxLength: 100, nullable: true),
                    NavyAgentCertFileName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermitClearanceaa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermitClearanceaa_ClearanceReason_ClearanceReasonId",
                        column: x => x.ClearanceReasonId,
                        principalTable: "ClearanceReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitClearanceaa_Passport_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitClearanceaa_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitClearanceaa_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermitRenews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    BirthPlaceId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false),
                    QualificationDate = table.Column<DateTime>(nullable: false),
                    JobTypeWorkPermitId = table.Column<int>(nullable: false),
                    JobNameInEgypt = table.Column<string>(maxLength: 100, nullable: false),
                    WorkPermitIssueReasonId = table.Column<int>(nullable: false),
                    PassportId = table.Column<int>(nullable: false),
                    ForeignContractorId = table.Column<int>(nullable: true),
                    PublicSectorId = table.Column<int>(nullable: true),
                    NidFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PassportFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PreviousPermitFileName = table.Column<string>(maxLength: 100, nullable: true),
                    VisaFileName = table.Column<string>(maxLength: 100, nullable: false),
                    VacationPermitFileName = table.Column<string>(maxLength: 100, nullable: true),
                    NavyAgentCertFileName = table.Column<string>(maxLength: 100, nullable: true),
                    NavyPassportFileName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermitRenews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_Country_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_ForeignContractor_ForeignContractorId",
                        column: x => x.ForeignContractorId,
                        principalTable: "ForeignContractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_JobTypeWorkPermit_JobTypeWorkPermitId",
                        column: x => x.JobTypeWorkPermitId,
                        principalTable: "JobTypeWorkPermit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_Passport_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_PublicSector_PublicSectorId",
                        column: x => x.PublicSectorId,
                        principalTable: "PublicSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitRenews_WorkPermitIssueReason_WorkPermitIssueReasonId",
                        column: x => x.WorkPermitIssueReasonId,
                        principalTable: "WorkPermitIssueReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPermitReplaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: true),
                    BirthPlaceId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false),
                    QualificationDate = table.Column<DateTime>(nullable: false),
                    JobTypeWorkPermitId = table.Column<int>(nullable: false),
                    JobNameInEgypt = table.Column<string>(maxLength: 100, nullable: false),
                    WorkPermitIssueReasonId = table.Column<int>(nullable: false),
                    PassportId = table.Column<int>(nullable: false),
                    ForeignContractorId = table.Column<int>(nullable: true),
                    PublicSectorId = table.Column<int>(nullable: true),
                    NidFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PassportFileName = table.Column<string>(maxLength: 100, nullable: false),
                    PreviousPermitFileName = table.Column<string>(maxLength: 100, nullable: true),
                    VisaFileName = table.Column<string>(maxLength: 100, nullable: false),
                    VacationPermitFileName = table.Column<string>(maxLength: 100, nullable: true),
                    NavyAgentCertFileName = table.Column<string>(maxLength: 100, nullable: true),
                    NavyPassportFileName = table.Column<string>(maxLength: 100, nullable: true),
                    IssuingGovernorateId = table.Column<int>(nullable: true),
                    IssuingUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermitReplaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Country_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_ForeignContractor_ForeignContractorId",
                        column: x => x.ForeignContractorId,
                        principalTable: "ForeignContractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Governorate_IssuingGovernorateId",
                        column: x => x.IssuingGovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Unit_IssuingUnitId",
                        column: x => x.IssuingUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_JobTypeWorkPermit_JobTypeWorkPermitId",
                        column: x => x.JobTypeWorkPermitId,
                        principalTable: "JobTypeWorkPermit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Passport_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_PublicSector_PublicSectorId",
                        column: x => x.PublicSectorId,
                        principalTable: "PublicSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPermitReplaces_WorkPermitIssueReason_WorkPermitIssueReasonId",
                        column: x => x.WorkPermitIssueReasonId,
                        principalTable: "WorkPermitIssueReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_GovernorateId",
                table: "Address",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PoliceDepartmentId",
                table: "Address",
                column: "PoliceDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PostalCodeId",
                table: "Address",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthDocs_GenderId",
                table: "BirthDocs",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthDocs_RelationId",
                table: "BirthDocs",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthDocs_RequestId",
                table: "BirthDocs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthDocs_StateId",
                table: "BirthDocs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_RegionId",
                table: "Country",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalStateRecords_RequestId",
                table: "CriminalStateRecords",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalStateRecords_StateId",
                table: "CriminalStateRecords",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathDocs_GenderId",
                table: "DeathDocs",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathDocs_RelationId",
                table: "DeathDocs",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathDocs_RequestId",
                table: "DeathDocs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DeathDocs_StateId",
                table: "DeathDocs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DivorceDocs_RelationId",
                table: "DivorceDocs",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DivorceDocs_RequestId",
                table: "DivorceDocs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DivorceDocs_StateId",
                table: "DivorceDocs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_IssuerId",
                table: "DocumentType",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeRelations_GenderId",
                table: "DocumentTypeRelations",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypeRelations_RelationId",
                table: "DocumentTypeRelations",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRecords_GenderId",
                table: "FamilyRecords",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRecords_RelationId",
                table: "FamilyRecords",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRecords_RequestId",
                table: "FamilyRecords",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyRecords_StateId",
                table: "FamilyRecords",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignContractor_AddressCountryId",
                table: "ForeignContractor",
                column: "AddressCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignContractor_ContractTypeId",
                table: "ForeignContractor",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignContractor_ContractorCountryId",
                table: "ForeignContractor",
                column: "ContractorCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignContractor_ContractorTypeId",
                table: "ForeignContractor",
                column: "ContractorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignContractor_CurrencyId",
                table: "ForeignContractor",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernmentalEstablishment_GovernmentalEstablishmentTypeId",
                table: "GovernmentalEstablishment",
                column: "GovernmentalEstablishmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageDocs_RelationId",
                table: "MarriageDocs",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageDocs_RequestId",
                table: "MarriageDocs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MarriageDocs_StateId",
                table: "MarriageDocs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_NidDocs_JobTypeNIDId",
                table: "NidDocs",
                column: "JobTypeNIDId");

            migrationBuilder.CreateIndex(
                name: "IX_NidDocs_NidIssueReasonId",
                table: "NidDocs",
                column: "NidIssueReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_NidDocs_RequestId",
                table: "NidDocs",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_NidDocs_StateId",
                table: "NidDocs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_JobInPassportId",
                table: "Passport",
                column: "JobInPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_PassportIssueCountryId",
                table: "Passport",
                column: "PassportIssueCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_PassportIssuerId",
                table: "Passport",
                column: "PassportIssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_RequestId",
                table: "PaymentDetails",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_RequestId",
                table: "PersonalRecords",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalRecords_StateId",
                table: "PersonalRecords",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceDepartment_GovernorateId",
                table: "PoliceDepartment",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_GovernorateId",
                table: "PostalCode",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_PoliceDepartmentId",
                table: "PostalCode",
                column: "PoliceDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSector_GovernmentalEstablishmentId",
                table: "PublicSector",
                column: "GovernmentalEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSector_VacationTypeId",
                table: "PublicSector",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_QualificationTypeId",
                table: "Qualification",
                column: "QualificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulations_JobTypeNIDId",
                table: "Regulations",
                column: "JobTypeNIDId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFawry_OrderStatusId",
                table: "RequestFawry",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryAddressId",
                table: "Requests",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_GenderId",
                table: "Requests",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IssuerId",
                table: "Requests",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PaymentMethodId",
                table: "Requests",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ResidencyAddressId",
                table: "Requests",
                column: "ResidencyAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_RejectionReasonId",
                table: "RequestState",
                column: "RejectionReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_RequestEFinanceId",
                table: "RequestState",
                column: "RequestEFinanceId",
                unique: true,
                filter: "[RequestEFinanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_RequestFawryId",
                table: "RequestState",
                column: "RequestFawryId",
                unique: true,
                filter: "[RequestFawryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_RequestId",
                table: "RequestState",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_RequestPostalId",
                table: "RequestState",
                column: "RequestPostalId",
                unique: true,
                filter: "[RequestPostalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_ReturnReasonId",
                table: "RequestState",
                column: "ReturnReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestState_StateId",
                table: "RequestState",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_GovernorateId",
                table: "Unit",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitClearanceaa_ClearanceReasonId",
                table: "WorkPermitClearanceaa",
                column: "ClearanceReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitClearanceaa_PassportId",
                table: "WorkPermitClearanceaa",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitClearanceaa_RequestId",
                table: "WorkPermitClearanceaa",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitClearanceaa_StateId",
                table: "WorkPermitClearanceaa",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_BirthPlaceId",
                table: "WorkPermitRenews",
                column: "BirthPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_ForeignContractorId",
                table: "WorkPermitRenews",
                column: "ForeignContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_JobTypeWorkPermitId",
                table: "WorkPermitRenews",
                column: "JobTypeWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_PassportId",
                table: "WorkPermitRenews",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_PublicSectorId",
                table: "WorkPermitRenews",
                column: "PublicSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_QualificationId",
                table: "WorkPermitRenews",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_RequestId",
                table: "WorkPermitRenews",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_StateId",
                table: "WorkPermitRenews",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRenews_WorkPermitIssueReasonId",
                table: "WorkPermitRenews",
                column: "WorkPermitIssueReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_BirthPlaceId",
                table: "WorkPermitReplaces",
                column: "BirthPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_ForeignContractorId",
                table: "WorkPermitReplaces",
                column: "ForeignContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_IssuingGovernorateId",
                table: "WorkPermitReplaces",
                column: "IssuingGovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_IssuingUnitId",
                table: "WorkPermitReplaces",
                column: "IssuingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_JobTypeWorkPermitId",
                table: "WorkPermitReplaces",
                column: "JobTypeWorkPermitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_PassportId",
                table: "WorkPermitReplaces",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_PublicSectorId",
                table: "WorkPermitReplaces",
                column: "PublicSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_QualificationId",
                table: "WorkPermitReplaces",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_RequestId",
                table: "WorkPermitReplaces",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_StateId",
                table: "WorkPermitReplaces",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitReplaces_WorkPermitIssueReasonId",
                table: "WorkPermitReplaces",
                column: "WorkPermitIssueReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthDocs");

            migrationBuilder.DropTable(
                name: "CriminalStateRecords");

            migrationBuilder.DropTable(
                name: "DeathDocs");

            migrationBuilder.DropTable(
                name: "DivorceDocs");

            migrationBuilder.DropTable(
                name: "DocumentTypeRelations");

            migrationBuilder.DropTable(
                name: "EligibleNID");

            migrationBuilder.DropTable(
                name: "FamilyRecords");

            migrationBuilder.DropTable(
                name: "MarriageDocs");

            migrationBuilder.DropTable(
                name: "Ministry");

            migrationBuilder.DropTable(
                name: "NidDocs");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "PersonalRecords");

            migrationBuilder.DropTable(
                name: "Regulations");

            migrationBuilder.DropTable(
                name: "RequestState");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WorkPermitClearanceaa");

            migrationBuilder.DropTable(
                name: "WorkPermitRenews");

            migrationBuilder.DropTable(
                name: "WorkPermitReplaces");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "NidIssueReason");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "JobTypeNID");

            migrationBuilder.DropTable(
                name: "RejectionReason");

            migrationBuilder.DropTable(
                name: "RequestEFinance");

            migrationBuilder.DropTable(
                name: "RequestFawry");

            migrationBuilder.DropTable(
                name: "RequestPostal");

            migrationBuilder.DropTable(
                name: "ReturnReason");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClearanceReason");

            migrationBuilder.DropTable(
                name: "ForeignContractor");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "JobTypeWorkPermit");

            migrationBuilder.DropTable(
                name: "Passport");

            migrationBuilder.DropTable(
                name: "PublicSector");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "WorkPermitIssueReason");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ForeignContractType");

            migrationBuilder.DropTable(
                name: "ForeignContractorType");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "PassportIssuer");

            migrationBuilder.DropTable(
                name: "GovernmentalEstablishment");

            migrationBuilder.DropTable(
                name: "VacationType");

            migrationBuilder.DropTable(
                name: "QualificationType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Issuer");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "GovernmentalEstablishmentType");

            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "PoliceDepartment");

            migrationBuilder.DropTable(
                name: "Governorate");
        }
    }
}
