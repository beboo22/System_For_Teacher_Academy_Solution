using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStructure.Data.migrations
{
    /// <inheritdoc />
    public partial class updateAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "examSubmissions");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "examSubmissions");

            migrationBuilder.CreateIndex(
                name: "IX_answers_QuestionId",
                table: "answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_QuestionId",
                table: "answers",
                column: "QuestionId",
                principalTable: "questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_QuestionId",
                table: "answers");

            migrationBuilder.DropIndex(
                name: "IX_answers_QuestionId",
                table: "answers");

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                table: "examSubmissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "examSubmissions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
