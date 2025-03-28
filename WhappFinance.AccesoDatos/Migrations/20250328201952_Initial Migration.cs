using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhappFinance.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "phonenumber",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: false),
                    contactname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phonenumber", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientdata",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_wa = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    idphonenumber = table.Column<int>(type: "integer", nullable: false),
                    idcategoria = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientdata", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientdata_phonenumber_idcategoria",
                        column: x => x.idcategoria,
                        principalSchema: "dbo",
                        principalTable: "phonenumber",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientdata_idcategoria",
                schema: "dbo",
                table: "clientdata",
                column: "idcategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientdata",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "phonenumber",
                schema: "dbo");
        }
    }
}
