using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Insert into AspNetRoles (Id, [name], [NormalizedName])
                values ('641f9dab-85d4-453c-8923-7c3908869102', 'Admin', 'Admin')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete AspNetRoles where Id = '641f9dab-85d4-453c-8923-7c3908869102'");
        }
    }
}
