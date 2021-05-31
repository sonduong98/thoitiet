using System.Collections.Generic;
using System.Web.Mvc;

namespace Models.Categories
{
    public class CategoryViewModel :BaseViewModel
    {
        public CategoryViewModel()
        {
            ListCategories = new List<CategoryModel>();
            InfoCategory = new CategoryModel();
            NameCategories = new List<SelectListItem>();
        }
        public List<CategoryModel> ListCategories { get; set; }
        public CategoryModel InfoCategory { get; set; }
        public List<SelectListItem> NameCategories { get; set; }
    }
}
