using Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FEPost
{
    public class FEPostModel
    {
        public FEPostModel()
        {
            PostDetail = new PostModel();
            Top3PostRelative = new List<PostModel>();
            PostNext = new List<PostModel>();
        }
        public PostModel PostDetail { get; set; }
        public List<PostModel> Top3PostRelative { get; set; }
        public List<PostModel> PostNext { get; set; }
    }
}
