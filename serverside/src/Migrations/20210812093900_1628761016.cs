using System;
using Cis.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis.Migrations
{
    public partial class _1628761016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionalAreaTimelineEvents");

            migrationBuilder.DropColumn(
                name: "Noservices",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Totalinvestment",
                table: "RegionalArea");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .Annotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<Categories>(
                name: "Category",
                table: "Service",
                type: "categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .OldAnnotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Service",
                type: "text",
                nullable: false,
                oldClrType: typeof(Categories),
                oldType: "categories");

            migrationBuilder.AddColumn<int>(
                name: "Noservices",
                table: "RegionalArea",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Totalinvestment",
                table: "RegionalArea",
                type: "double precision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegionalAreaTimelineEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ActionTitle = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalAreaTimelineEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionalAreaTimelineEvents_RegionalArea_EntityId",
                        column: x => x.EntityId,
                        principalTable: "RegionalArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionalAreaTimelineEvents_EntityId",
                table: "RegionalAreaTimelineEvents",
                column: "EntityId");
        }
    }
}
