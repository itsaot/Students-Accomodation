using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication20.Migrations.Condition
{
    /// <inheritdoc />
    public partial class con : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studyDesk = table.Column<int>(type: "int", nullable: false),
                    fridge = table.Column<int>(type: "int", nullable: false),
                    mattress = table.Column<int>(type: "int", nullable: false),
                    wallSocket = table.Column<int>(type: "int", nullable: false),
                    chair = table.Column<int>(type: "int", nullable: false),
                    stove = table.Column<int>(type: "int", nullable: false),
                    lightSwitches = table.Column<int>(type: "int", nullable: false),
                    ConditionImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condition");
        }
    }
}
