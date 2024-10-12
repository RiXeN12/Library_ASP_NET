namespace Library_NPR321.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<FavoriteBookVM> Books { get; set; } = new List<FavoriteBookVM>();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    }
}
