﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSettings.Migrations.Sqlite.Data.Migrations.OpenSettings.OpenSettingsDb
{
    /// <inheritdoc />
    public partial class OpenSettingsDbMigration_v1_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Configurations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spa",
                table: "Configurations",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "Spa",
                table: "Configurations");
        }
    }
}
