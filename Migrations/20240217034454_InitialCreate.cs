using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SWAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "C_BAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    refno = table.Column<string>(type: "longtext", nullable: false),
                    sdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    cuscode = table.Column<string>(type: "longtext", nullable: false),
                    amount = table.Column<double>(type: "double", nullable: false),
                    trn_type = table.Column<string>(type: "longtext", nullable: false),
                    gst = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_BAL", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dep_cheq_mas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dep_cheq_mas", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "s_comm",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ref_no = table.Column<string>(type: "longtext", nullable: true),
                    invno = table.Column<string>(type: "longtext", nullable: true),
                    sdate = table.Column<DateOnly>(type: "date", nullable: true),
                    amount = table.Column<double>(type: "double", nullable: false),
                    descr = table.Column<string>(type: "longtext", nullable: true),
                    company = table.Column<string>(type: "longtext", nullable: true),
                    mtype = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_comm", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "s_mas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    stk_no = table.Column<string>(type: "longtext", nullable: true),
                    part_no = table.Column<string>(type: "longtext", nullable: true),
                    brand_name = table.Column<string>(type: "longtext", nullable: true),
                    substitute = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_s_mas", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "S_SALMA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ref_no = table.Column<string>(type: "longtext", nullable: false),
                    c_code = table.Column<string>(type: "longtext", nullable: false),
                    cus_name = table.Column<string>(type: "longtext", nullable: false),
                    sdate = table.Column<DateOnly>(type: "date", nullable: true),
                    grand_tot = table.Column<double>(type: "double", nullable: false),
                    gst = table.Column<double>(type: "double", nullable: false),
                    company = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_SALMA", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sp_discount_trn",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    sdate = table.Column<DateOnly>(type: "date", nullable: false),
                    stk_no = table.Column<string>(type: "longtext", nullable: false),
                    dis1 = table.Column<double>(type: "double", nullable: false),
                    dis2 = table.Column<double>(type: "double", nullable: false),
                    sptot = table.Column<double>(type: "double", nullable: false),
                    reason = table.Column<string>(type: "longtext", nullable: false),
                    inv_id = table.Column<int>(type: "int", nullable: true),
                    ref_no = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sp_discount_trn", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_appoinments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    slot = table.Column<int>(type: "int", nullable: true),
                    c_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    sdate = table.Column<DateOnly>(type: "date", nullable: true),
                    contno = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    stk_no = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    descript = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    qty = table.Column<double>(type: "double", nullable: true),
                    vehno = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    aptype = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_appoinments", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "longtext", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false),
                    town = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dep_cheq_trn",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    depositid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dep_cheq_trn", x => x.id);
                    table.ForeignKey(
                        name: "FK_dep_cheq_trn_dep_cheq_mas_depositid",
                        column: x => x.depositid,
                        principalTable: "dep_cheq_mas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_dep_cheq_trn_depositid",
                table: "dep_cheq_trn",
                column: "depositid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C_BAL");

            migrationBuilder.DropTable(
                name: "dep_cheq_trn");

            migrationBuilder.DropTable(
                name: "s_comm");

            migrationBuilder.DropTable(
                name: "s_mas");

            migrationBuilder.DropTable(
                name: "S_SALMA");

            migrationBuilder.DropTable(
                name: "sp_discount_trn");

            migrationBuilder.DropTable(
                name: "tb_appoinments");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "dep_cheq_mas");
        }
    }
}
