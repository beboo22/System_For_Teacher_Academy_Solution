using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStructure.Data.migrations
{
    /// <inheritdoc />
    public partial class StudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_AspNetUsers_StdId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubmissions_AspNetUsers_studentId",
                table: "examSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_lessonPurchases_AspNetUsers_StdId",
                table: "lessonPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_AspNetUsers_StudentsId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_progresses_AspNetUsers_StudentId",
                table: "progresses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GuardianPhNum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GuardianType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StdPhNum",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    StdPhNum = table.Column<string>(type: "text", nullable: false),
                    GuardianType = table.Column<string>(type: "text", nullable: false),
                    GuardianPhNum = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    SchoolYear = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Id",
                table: "Students",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_Students_StdId",
                table: "enrollments",
                column: "StdId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubmissions_Students_studentId",
                table: "examSubmissions",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lessonPurchases_Students_StdId",
                table: "lessonPurchases",
                column: "StdId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Students_StudentsId",
                table: "messages",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_progresses_Students_StudentId",
                table: "progresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollments_Students_StdId",
                table: "enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_examSubmissions_Students_studentId",
                table: "examSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_lessonPurchases_Students_StdId",
                table: "lessonPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Students_StudentsId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_progresses_Students_StudentId",
                table: "progresses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GuardianPhNum",
                table: "AspNetUsers",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianType",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StdPhNum",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollments_AspNetUsers_StdId",
                table: "enrollments",
                column: "StdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_examSubmissions_AspNetUsers_studentId",
                table: "examSubmissions",
                column: "studentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lessonPurchases_AspNetUsers_StdId",
                table: "lessonPurchases",
                column: "StdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_AspNetUsers_StudentsId",
                table: "messages",
                column: "StudentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_progresses_AspNetUsers_StudentId",
                table: "progresses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
