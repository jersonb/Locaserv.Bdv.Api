using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Locaserv.Bdv.Api.Data.Migrations
{
    public partial class AddCarsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOnly",
                schema: "bdv",
                table: "test");

            migrationBuilder.DropColumn(
                name: "TimeOnly",
                schema: "bdv",
                table: "test");

            migrationBuilder.CreateTable(
                name: "car",
                schema: "bdv",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    find_id = table.Column<Guid>(type: "uuid", nullable: false),
                    internal_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    license_plate = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car",
                schema: "bdv");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOnly",
                schema: "bdv",
                table: "test",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeOnly",
                schema: "bdv",
                table: "test",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
