using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArbiTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImpossibleFutureApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpossibleFutureApps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Topics = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    BlockNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BlockHash = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<string>(type: "TEXT", nullable: false),
                    GasPrice = table.Column<string>(type: "TEXT", nullable: false),
                    GasUsed = table.Column<string>(type: "TEXT", nullable: false),
                    LogIndex = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionHash = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionIndex = table.Column<string>(type: "TEXT", nullable: false),
                    ImpossibleFutureAppModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_ImpossibleFutureApps_ImpossibleFutureAppModelId",
                        column: x => x.ImpossibleFutureAppModelId,
                        principalTable: "ImpossibleFutureApps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ImpossibleFutureAppModelId",
                table: "Logs",
                column: "ImpossibleFutureAppModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ImpossibleFutureApps");
        }
    }
}
