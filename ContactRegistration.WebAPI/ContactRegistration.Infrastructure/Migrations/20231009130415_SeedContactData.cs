using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var basePath = Path.GetFullPath("ContactRegistration.WebAPI").Replace("ContactRegistration.WebAPI\\", "");
            var seedingPath = Path.Combine(basePath, "ContactRegistration.Infrastructure\\Seedings\\SQL\\");
            
            var scriptFile = seedingPath + "20231009_InitialSeeding.sql";

            var rawScript = File.ReadAllText(scriptFile);
            migrationBuilder.Sql(rawScript);
        }
    }
}
