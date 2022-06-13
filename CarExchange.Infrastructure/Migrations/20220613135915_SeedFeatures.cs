using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarExchange.Infrastructure.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CarId", "Name" },
                values: new object[,]
                {
                    { "1a28eea6-8159-42fa-9389-588e32dd94e7", null, "Seat - Height Adjustment" },
                    { "5fbdc6e8-20ef-49fd-a7f2-dadc53def7a8", null, "LED lights" },
                    { "6e040908-5d77-4462-a3d5-f90b4d9b7849", null, "Parking Sensors" },
                    { "80af5358-9fd3-477f-9618-e7e713618489", null, "Front Fog Lights" },
                    { "83ea7719-a6f6-42d6-bf56-823a64a3a1a4", null, "Lane Assist" },
                    { "8a1a7eac-60e6-48a2-889f-8e6387a5bbfc", null, "Leather Saloon" },
                    { "ae0ee0f4-b230-4cd7-93d8-3e7e75c8e8f4", null, "Electric Windows" },
                    { "afb9b2f6-ecda-4a62-b173-c013a0be9b89", null, "Side Airbags" },
                    { "b8ce9dea-4e68-4492-989c-77b815503eb1", null, "Bluetooth" },
                    { "c6a58d6s-38f6-44d1-9b6a-209be04fbi43", null, "Heater rear window" },
                    { "cd2507c1-766b-4852-bda9-ebf56a587167", null, "USB" },
                    { "d6f58d6c-83f6-44d1-9b6a-205be04fb447", null, "Alarm" },
                    { "d6f58d6c-83f6-k1d1-y56a-205be04fb447", null, "ABS" },
                    { "ec5eba28-d1c2-481d-aad9-f70cfaab95dd", null, "Leather seats" },
                    { "ee88e9b0-b98a-4ca0-a520-789cab1b3f52", null, "Navigation system" },
                    { "efe890d8-e7a4-41a3-a45a-adf3ee0b18df", null, "Airbags" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "1a28eea6-8159-42fa-9389-588e32dd94e7");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "5fbdc6e8-20ef-49fd-a7f2-dadc53def7a8");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "6e040908-5d77-4462-a3d5-f90b4d9b7849");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "80af5358-9fd3-477f-9618-e7e713618489");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "83ea7719-a6f6-42d6-bf56-823a64a3a1a4");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "8a1a7eac-60e6-48a2-889f-8e6387a5bbfc");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "ae0ee0f4-b230-4cd7-93d8-3e7e75c8e8f4");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "afb9b2f6-ecda-4a62-b173-c013a0be9b89");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "b8ce9dea-4e68-4492-989c-77b815503eb1");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "c6a58d6s-38f6-44d1-9b6a-209be04fbi43");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "cd2507c1-766b-4852-bda9-ebf56a587167");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "d6f58d6c-83f6-44d1-9b6a-205be04fb447");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "d6f58d6c-83f6-k1d1-y56a-205be04fb447");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "ec5eba28-d1c2-481d-aad9-f70cfaab95dd");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "ee88e9b0-b98a-4ca0-a520-789cab1b3f52");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: "efe890d8-e7a4-41a3-a45a-adf3ee0b18df");
        }
    }
}
