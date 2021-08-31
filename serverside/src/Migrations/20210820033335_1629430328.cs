using System;
using Cis.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cis.Migrations
{
    public partial class _1629430328 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metric");

            migrationBuilder.DropTable(
                name: "RegionalAreaTimelineEvents");

            migrationBuilder.DropColumn(
                name: "Noservices",
                table: "RegionalArea");

            migrationBuilder.DropColumn(
                name: "Totalinvestment",
                table: "RegionalArea");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .Annotation("Npgsql:Enum:gender", "female,male,other")
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

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Service",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Agemax",
                table: "Service",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Agemin",
                table: "Service",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Service",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Enddate",
                table: "Service",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Gender>(
                name: "Gender",
                table: "Service",
                type: "gender",
                nullable: false,
                defaultValue: Gender.FEMALE);

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdate",
                table: "Service",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "HangfireState",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HangfireState",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "HangfireSet",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "HangfireServer",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Queue",
                table: "HangfireQueuedJob",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "HangfireLock",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireList",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HangfireJobParameter",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "HangfireJob",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Field",
                table: "HangfireHash",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireHash",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireCounter",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "PreferredTwoFactorMethod",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_Active",
                table: "Service",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Enddate",
                table: "Service",
                column: "Enddate");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Investment",
                table: "Service",
                column: "Investment");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Startdate",
                table: "Service",
                column: "Startdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Service_Active",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_Enddate",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_Investment",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_Startdate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Agemax",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Agemin",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Enddate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Startdate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "PreferredTwoFactorMethod",
                table: "AspNetUsers");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:servicetype", "permanent,visiting")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .OldAnnotation("Npgsql:Enum:categories", "aboriginal_service,accommodation_service,advocacy_service,alcohol_and_drug_service,animal_service,arts_and_creatives,child_service,communication_and_information,community_centres_halls_and_facilities,community_club,crisis_and_emergency_service,cultural_and_migrant_service,disability_service,education,employment_and_training,environment_and_conservation,health_service,information_and_counselling,legal_service,industry_and_funding_bodies,recreation_and_leisure,religion_and_philosophy,self_help,sport,transport_service,volunteering,welfare_assistance,youth_service")
                .OldAnnotation("Npgsql:Enum:gender", "female,male,other")
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

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "HangfireState",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HangfireState",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "HangfireSet",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "HangfireServer",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Queue",
                table: "HangfireQueuedJob",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "HangfireLock",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireList",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HangfireJobParameter",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "HangfireJob",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Field",
                table: "HangfireHash",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireHash",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HangfireCounter",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Metric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metric", x => x.Id);
                });

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
