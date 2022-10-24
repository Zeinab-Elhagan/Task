using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVENTS.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EC");

            migrationBuilder.CreateTable(
                name: " Sources",
                schema: "EC",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceTitle = table.Column<string>(type: "varchar(250)", nullable: false),
                    SourceDescription = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Sources", x => x.SourceId);
                });

            migrationBuilder.CreateTable(
                name: "Catogories",
                schema: "EC",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(250)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    EventTitle = table.Column<string>(type: "varchar(250)", nullable: false),
                    EventContent = table.Column<string>(type: "varchar(1000)", nullable: true),
                    EventAddress = table.Column<string>(type: "varchar(250)", nullable: true),
                    EventStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventCoverphoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    source = table.Column<string>(type: "varchar(250)", nullable: true),
                    albums = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "varchar(250)", nullable: true),
                    SourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_ Sources_EventId",
                        column: x => x.EventId,
                        principalSchema: "EC",
                        principalTable: " Sources",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_ Sources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "EC",
                        principalTable: " Sources",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: " photoalbums",
                schema: "EC",
                columns: table => new
                {
                    photoalbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photoalbumTitle = table.Column<string>(type: "varchar(250)", nullable: false),
                    Multiphotoalbums = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ photoalbums", x => x.photoalbumId);
                    table.ForeignKey(
                        name: "FK_ photoalbums_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    _EventsEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.CategoriesCategoryId, x._EventsEventId });
                    table.ForeignKey(
                        name: "FK_Categories_Catogories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalSchema: "EC",
                        principalTable: "Catogories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Events__EventsEventId",
                        column: x => x._EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ photoalbums_EventId",
                schema: "EC",
                table: " photoalbums",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories__EventsEventId",
                table: "Categories",
                column: "_EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SourceId",
                table: "Events",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " photoalbums",
                schema: "EC");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Catogories",
                schema: "EC");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: " Sources",
                schema: "EC");
        }
    }
}
