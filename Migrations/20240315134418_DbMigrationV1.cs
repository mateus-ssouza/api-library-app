using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class DbMigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"), "J.R.R. Tolkien", "9780547928227", "O Hobbit" },
                    { new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"), "Suzanne Collins", "9780439023528", "Jogos Vorazes" },
                    { new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"), "Philip Reeve", "9780060082070", "Máquinas Mortais" },
                    { new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"), "Lewis Carroll", "9780061121907", "As Aventuras de Alice no País das Maravilhas" },
                    { new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"), "Ursula K. Le Guin", "9780547773742", "Um Feiticeiro de Terramar" }
                });

            migrationBuilder.InsertData(
                table: "Copies",
                columns: new[] { "Id", "Available", "BookId", "CopyCode" },
                values: new object[,]
                {
                    { new Guid("03f89e6d-aeb7-4970-90ef-5811d4f18a65"), true, new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"), "B001" },
                    { new Guid("1cf1dcbf-9c4e-4aa9-8652-4e2ba50847d0"), true, new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"), "E003" },
                    { new Guid("28e06c2f-5329-4760-95fb-dc40733b2ab5"), true, new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"), "A002" },
                    { new Guid("2d8e7e57-a771-4e1b-9bee-f3a43dcfbc72"), true, new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"), "E001" },
                    { new Guid("418c8559-e10f-402d-851f-091f2636ad0d"), true, new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"), "D002" },
                    { new Guid("5d8a4b9e-25ed-44b4-8fbb-12b60fd19af8"), true, new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"), "B002" },
                    { new Guid("6bc145ad-87ca-437f-ac49-2106799cb4e2"), true, new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"), "D001" },
                    { new Guid("6e22fd39-bdd5-4756-8cea-306da06079e3"), true, new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"), "C001" },
                    { new Guid("93c0f4db-a9a0-41fe-8925-02846a3b27d8"), true, new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"), "C002" },
                    { new Guid("a14f200f-a22f-42df-aaf5-07953f728862"), true, new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"), "A004" },
                    { new Guid("ac9300dc-f2fa-43c3-8794-28d2a359563d"), true, new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"), "D003" },
                    { new Guid("afdd9f71-81bc-44e6-9330-db498e36faf1"), true, new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"), "C003" },
                    { new Guid("b7efe9e9-66f9-4dd9-8729-8eccc63c53e5"), true, new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"), "C004" },
                    { new Guid("bc2cb666-aac0-439f-b546-6c37135d7f45"), true, new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"), "E002" },
                    { new Guid("de70b5cc-560d-4ccc-80ee-1b221ec227da"), true, new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"), "A003" },
                    { new Guid("e1908131-b1f7-4f6b-b831-4c1080c46930"), true, new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"), "A001" },
                    { new Guid("ecbf8148-7f07-423d-b227-a2213e0b3509"), true, new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"), "B004" },
                    { new Guid("f46d8858-0b19-45cc-bc5a-c3a4a6fed77c"), true, new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"), "B003" },
                    { new Guid("fb938939-ea99-4f52-aa12-2668030cd62b"), true, new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"), "E004" },
                    { new Guid("ff0fd245-4d4d-411e-a146-613673e3ceaa"), true, new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"), "D004" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("03f89e6d-aeb7-4970-90ef-5811d4f18a65"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("1cf1dcbf-9c4e-4aa9-8652-4e2ba50847d0"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("28e06c2f-5329-4760-95fb-dc40733b2ab5"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("2d8e7e57-a771-4e1b-9bee-f3a43dcfbc72"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("418c8559-e10f-402d-851f-091f2636ad0d"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("5d8a4b9e-25ed-44b4-8fbb-12b60fd19af8"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("6bc145ad-87ca-437f-ac49-2106799cb4e2"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("6e22fd39-bdd5-4756-8cea-306da06079e3"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("93c0f4db-a9a0-41fe-8925-02846a3b27d8"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("a14f200f-a22f-42df-aaf5-07953f728862"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("ac9300dc-f2fa-43c3-8794-28d2a359563d"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("afdd9f71-81bc-44e6-9330-db498e36faf1"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("b7efe9e9-66f9-4dd9-8729-8eccc63c53e5"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("bc2cb666-aac0-439f-b546-6c37135d7f45"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("de70b5cc-560d-4ccc-80ee-1b221ec227da"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("e1908131-b1f7-4f6b-b831-4c1080c46930"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("ecbf8148-7f07-423d-b227-a2213e0b3509"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("f46d8858-0b19-45cc-bc5a-c3a4a6fed77c"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("fb938939-ea99-4f52-aa12-2668030cd62b"));

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: new Guid("ff0fd245-4d4d-411e-a146-613673e3ceaa"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("03070683-6607-4d1f-88ba-c4f92d0c4cb3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1d00dffc-57a9-4547-b74e-3fdf02827708"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7b66e07a-eaa0-468d-90dd-390ebf16bbf7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b351e787-180d-4c99-8ad2-ce89d37106b2"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e889b64d-d435-4a6d-a95d-73c2ff37ee0e"));
        }
    }
}
