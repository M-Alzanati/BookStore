using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class ModifyAuthorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Nationalities_NationalityId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Books",
                type: "varchar(767)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalityId",
                table: "Authors",
                type: "varchar(767)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Nationalities_NationalityId",
                table: "Authors",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Nationalities_NationalityId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Books",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(767)");

            migrationBuilder.AlterColumn<string>(
                name: "NationalityId",
                table: "Authors",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(767)");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Nationalities_NationalityId",
                table: "Authors",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
