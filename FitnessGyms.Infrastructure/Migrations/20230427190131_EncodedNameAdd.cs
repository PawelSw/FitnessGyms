using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessGyms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EncodedNameAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "FitnessGyms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "FitnessGyms");
        }
    }
}
