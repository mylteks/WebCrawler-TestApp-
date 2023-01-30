using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppDB.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requesttime = table.Column<DateTime>(name: "Request time", type: "datetime2", nullable: false),
                    WebsiteName = table.Column<string>(name: "Website Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timing = table.Column<double>(type: "float", nullable: false),
                    RequestInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestResult_RequestInfo_RequestInfoId",
                        column: x => x.RequestInfoId,
                        principalTable: "RequestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestResult_RequestInfoId",
                table: "RequestResult",
                column: "RequestInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestResult");

            migrationBuilder.DropTable(
                name: "RequestInfo");
        }
    }
}
