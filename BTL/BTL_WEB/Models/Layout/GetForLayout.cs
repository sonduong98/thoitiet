using Models.Categories;
using Models.Post;
using Models.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Layout
{
    public class GetForLayout
    {
        public GetForLayout()
        {
            Menu = new List<CategoryModel>();
            Top12Post = new List<PostModel>();
            InfoCategory = new List<CategoryModel>();
            Tags = new List<TagModel>();
            PostPopular = new List<PostModel>();
        }
        public List<CategoryModel> Menu { get; set; }
        public List<PostModel> Top12Post { get; set; }
        public List<CategoryModel> InfoCategory { get; set; }
        public List<TagModel>  Tags{ get; set; }
        public List<PostModel> PostPopular { get; set; }
    }
}
