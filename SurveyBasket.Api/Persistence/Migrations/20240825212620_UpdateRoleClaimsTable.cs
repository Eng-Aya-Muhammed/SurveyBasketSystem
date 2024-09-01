using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleClaimsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6dc6528a-b280-4770-9eae-82671ee81ef7",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHr553pMLlu3A3ATzZKABiNkg0XkIKAsru1cXF6XvvsL/E9SW+RHRpItUKlnDlfa2w==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6dc6528a-b280-4770-9eae-82671ee81ef7",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAho9nn3nmhS3p7t5NP7/kjW2yUoKceuLF418VhDbFcb9/dYGszpnBbMg3uSBIgYaA==");
        }
    }
}
