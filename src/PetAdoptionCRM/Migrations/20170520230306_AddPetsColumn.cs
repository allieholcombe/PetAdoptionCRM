using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetAdoptionCRM.Migrations
{
    public partial class AddPetsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    Adopted = table.Column<bool>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    IntakeDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Neutered = table.Column<bool>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
