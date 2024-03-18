using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoLoja.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "VARCHAR", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "VARCHAR", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Pk_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Pk_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR", nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    IsAdmin = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Pk_Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalAmount = table.Column<double>(type: "REAL", nullable: false),
                    Fk_UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "Fk_CartXUser",
                        column: x => x.Fk_UserId,
                        principalTable: "Users",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalAmount = table.Column<double>(type: "REAL", nullable: false),
                    Fk_UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    OrderState = table.Column<string>(type: "VARCHAR", nullable: false),
                    PaymentMethod = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "Fk_OrderXUser",
                        column: x => x.Fk_UserId,
                        principalTable: "Users",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartXProduct",
                columns: table => new
                {
                    Fk_CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fk_ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartXProduct", x => new { x.Fk_CartId, x.Fk_ProductId });
                    table.ForeignKey(
                        name: "Fk_CartXProduct_CartId",
                        column: x => x.Fk_CartId,
                        principalTable: "Carts",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_CartXProduct_ProductId",
                        column: x => x.Fk_ProductId,
                        principalTable: "Products",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderXProduct",
                columns: table => new
                {
                    Fk_OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fk_ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderXProduct", x => new { x.Fk_OrderId, x.Fk_ProductId });
                    table.ForeignKey(
                        name: "Fk_OrderXProduct_OrderId",
                        column: x => x.Fk_OrderId,
                        principalTable: "Orders",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_OrderXProduct_ProductId",
                        column: x => x.Fk_ProductId,
                        principalTable: "Products",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Fk_UserId",
                table: "Carts",
                column: "Fk_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartXProduct_Fk_ProductId",
                table: "CartXProduct",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Fk_UserId",
                table: "Orders",
                column: "Fk_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderXProduct_Fk_ProductId",
                table: "OrderXProduct",
                column: "Fk_ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartXProduct");

            migrationBuilder.DropTable(
                name: "OrderXProduct");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
