using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCrawlerDataBase.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestResult_RequestInfo_RequestInfoId",
                table: "RequestResult");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "RequestResult");

            migrationBuilder.AlterColumn<int>(
                name: "RequestInfoId",
                table: "RequestResult",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCrawl",
                table: "RequestResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSitemap",
                table: "RequestResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestResult_RequestInfo_RequestInfoId",
                table: "RequestResult",
                column: "RequestInfoId",
                principalTable: "RequestInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestResult_RequestInfo_RequestInfoId",
                table: "RequestResult");

            migrationBuilder.DropColumn(
                name: "IsCrawl",
                table: "RequestResult");

            migrationBuilder.DropColumn(
                name: "IsSitemap",
                table: "RequestResult");

            migrationBuilder.AlterColumn<int>(
                name: "RequestInfoId",
                table: "RequestResult",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "RequestResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestResult_RequestInfo_RequestInfoId",
                table: "RequestResult",
                column: "RequestInfoId",
                principalTable: "RequestInfo",
                principalColumn: "Id");
        }
    }
}
