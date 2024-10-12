using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_NPR321.Migrations
{
    /// <inheritdoc />
    public partial class addbooksdataseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Genre", "Image", "Language", "PageCount", "Publisher", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Перший роман серії «Гаррі Поттер» британської письменниці Дж. К. Ролінґ. Опублікований 30 червня 1997 року видавництвом «Блумсбері Паблішинґ» у Лондоні. В 2001 році було випущено однойменний художній фільм на основі роману.", "Епічне фентезі", null, "eng", 360, "КСД", "Гаррі Поттер і філософський камінь", (short)1997 },
                    { 2, 1, "Другий роман серії «Гаррі Поттер» британської письменниці Дж. К. Ролінґ. Вийшов 2 липня 1998 року у видавництві «Блумсбері Паблішинґ» у Лондоні. 2002 року на основі роману знято однойменний художній фільм.", "Епічне фентезі", null, "eng", 352, "КСД", "Гаррі Поттер і таємна кімната", (short)198 },
                    { 3, 2, "«Хранителі Персня» — перша частина роману англійського письменника Дж. Р. Р. Толкіна «Володар перснів», що публікується разом із прологом, який не входить до складу всієї книги. Складається з двох книг.", "Фентезі", null, "eng", 704, "КСД", "Володар перснів братство персня", (short)1954 },
                    { 4, 2, "«Дві твердині» — друга частина трилогії англійського письменника Дж. Р. Р. Толкіна «Володар перснів». Складається з двох частин. Опублікована у 1954 році у Лондоні.", "Фентезі", null, "eng", 576, "КСД", "Володар перснів дві твердині", (short)1954 },
                    { 5, 3, "«Воно́» — роман американського письменника Стівена Кінга, написаний у жанрі жахів, уперше опублікований 1986 року видавництвом Viking Press. У творі зачіпаються важливі для Кінга теми: влада пам'яті, сила в об'єднанні, вплив травм дитинства на доросле життя.", "Фантастика жахів", null, "eng", 1344, "КСД", "Воно", (short)1986 },
                    { 6, 3, "«Шукач» — роман американського письменника Стівена Кінга, що розпочинає серію романів про Темну Вежу, яку Кінг презентує як свій Magnum opus. Автор розпочав роботу над романом в 1970 році, а закінчив в 1980. Протягом 1978—1981 рр. роман публікувався окремими повістями в періодиці.", "Фентезі", null, "eng", 240, "КСД", "Темна Вежа I: Стрілець", (short)1982 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
