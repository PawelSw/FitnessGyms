using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessGyms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAddedToFitnessGym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "FitnessGyms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessGyms_CreatedById",
                table: "FitnessGyms",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessGyms_AspNetUsers_CreatedById",
                table: "FitnessGyms",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessGyms_AspNetUsers_CreatedById",
                table: "FitnessGyms");

            migrationBuilder.DropIndex(
                name: "IX_FitnessGyms_CreatedById",
                table: "FitnessGyms");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "FitnessGyms");
        }
    }
}
