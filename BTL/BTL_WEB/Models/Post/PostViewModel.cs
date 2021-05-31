using System.Collections.Generic;
using System.Web.Mvc;

namespace Models.Post
{
    public class PostViewModel :BaseViewModel
    {
        public PostViewModel()
        {
            ListPosts = new List<PostModel>();
            InfoPost = new PostModel();
            Cates = new List<SelectListItem>();
            ListTags = new List<SelectListItem>();
        }
        public List<PostModel> ListPosts { get; set; }
        public PostModel InfoPost { get; set; }
        public List<SelectListItem>  Cates{ get; set; }
        public List<SelectListItem> ListTags { get; set; }
    }
}
