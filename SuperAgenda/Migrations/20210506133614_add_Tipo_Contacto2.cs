using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperAgenda.Migrations
{
    public partial class add_Tipo_Contacto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Contacts");
        }
    }
}
