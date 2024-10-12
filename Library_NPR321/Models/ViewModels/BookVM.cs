using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_NPR321.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
}
}
