﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication20.Migrations
{
    /// <inheritdoc />
    public partial class nkosinathi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "StudentBooking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "StudentBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
