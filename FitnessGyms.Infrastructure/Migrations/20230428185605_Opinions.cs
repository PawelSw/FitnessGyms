using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessGyms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Opinions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opinions",
                table: "FitnessGyms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opinions",
                table: "FitnessGyms");
        }
    }
}
