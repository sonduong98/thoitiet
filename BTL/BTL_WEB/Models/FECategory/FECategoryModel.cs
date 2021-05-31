using Models.Categories;
using Models.Post;
using System.Collections.Generic;

namespace Models.FECategory
{
    public class FECategoryModel
    {
        public FECategoryModel()
        {
            CategoryDetail = new CategoryModel();
            PostByCategory = new List<PostModel>();
           
        }
        public CategoryModel CategoryDetail { get; set; }
        public List<PostModel> PostByCategory { get; set; }
    }
}
