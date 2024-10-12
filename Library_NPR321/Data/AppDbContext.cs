using Library_NPR321.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_NPR321.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Джоан",
                    LastName = "Роулінг",
                    Birthday = new DateTime(1965, 7, 31)
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Джон Рональд Руел",
                    LastName = "Толкін",
                    Birthday = new DateTime(1892, 1, 3)
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Стівен",
                    LastName = "Кінг",
                    Birthday = new DateTime(1947, 9, 21)
                }
                );

            // Books
            modelBuilder.Entity<Book>().HasData(
                new Book 
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Гаррі Поттер і філософський камінь",
                    Description = "Перший роман серії «Гаррі Поттер» британської письменниці Дж. К. Ролінґ. Опублікований 30 червня 1997 року видавництвом «Блумсбері Паблішинґ» у Лондоні. В 2001 році було випущено однойменний художній фільм на основі роману.",
                    Genre = "Епічне фентезі",
                    Language = "eng",
                    PageCount = 360,
                    Publisher = "КСД",
                    Year = 1997,
                    Image = "10ac9d5b-b28a-44c0-97ce-887533646261.jpg"
                },
                new Book
                {
                    Id = 2,
                    AuthorId = 1,
                    Title = "Гаррі Поттер і таємна кімната",
                    Description = "Другий роман серії «Гаррі Поттер» британської письменниці Дж. К. Ролінґ. Вийшов 2 липня 1998 року у видавництві «Блумсбері Паблішинґ» у Лондоні. 2002 року на основі роману знято однойменний художній фільм.",
                    Genre = "Епічне фентезі",
                    Language = "eng",
                    PageCount = 352,
                    Publisher = "КСД",
                    Year = 1998,
                    Image = "c4a53845-cb61-4168-8514-a28e15e27847.jpeg"
                },
                new Book
                {
                    Id = 3,
                    AuthorId = 2,
                    Title = "Володар перснів братство персня",
                    Description = "«Хранителі Персня» — перша частина роману англійського письменника Дж. Р. Р. Толкіна «Володар перснів», що публікується разом із прологом, який не входить до складу всієї книги. Складається з двох книг.",
                    Genre = "Фентезі",
                    Language = "eng",
                    PageCount = 704,
                    Publisher = "КСД",
                    Year = 1954,
                    Image = "73e98618-2b2b-4bc4-95f6-8ea99bf9f420.webp"
                },
                new Book
                {
                    Id = 4,
                    AuthorId = 2,
                    Title = "Володар перснів дві твердині",
                    Description = "«Дві твердині» — друга частина трилогії англійського письменника Дж. Р. Р. Толкіна «Володар перснів». Складається з двох частин. Опублікована у 1954 році у Лондоні.",
                    Genre = "Фентезі",
                    Language = "eng",
                    PageCount = 576,
                    Publisher = "КСД",
                    Year = 1954,
                    Image = "fc5687f7-1410-42b4-887b-3911a1b11a87.jpeg"
                },
                new Book
                {
                    Id = 5,
                    AuthorId = 3,
                    Title = "Воно",
                    Description = "«Воно́» — роман американського письменника Стівена Кінга, написаний у жанрі жахів, уперше опублікований 1986 року видавництвом Viking Press. У творі зачіпаються важливі для Кінга теми: влада пам'яті, сила в об'єднанні, вплив травм дитинства на доросле життя.",
                    Genre = "Фантастика жахів",
                    Language = "eng",
                    PageCount = 1344,
                    Publisher = "КСД",
                    Year = 1986,
                    Image = "c29f29d8-f54f-4ba0-b11d-f0cd90c811d2.jpeg"
                },
                new Book
                {
                    Id = 6,
                    AuthorId = 3,
                    Title = "Темна Вежа I: Стрілець",
                    Description = "«Шукач» — роман американського письменника Стівена Кінга, що розпочинає серію романів про Темну Вежу, яку Кінг презентує як свій Magnum opus. Автор розпочав роботу над романом в 1970 році, а закінчив в 1980. Протягом 1978—1981 рр. роман публікувався окремими повістями в періодиці.",
                    Genre = "Фентезі",
                    Language = "eng",
                    PageCount = 240,
                    Publisher = "КСД",
                    Year = 1982,
                    Image = "21a02fd7-f503-40e9-b1f1-26b07def8eae.jpeg"
                }

                );
        }
    }
}
