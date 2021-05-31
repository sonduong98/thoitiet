using Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Layout
{
    public class IndexModel
    {
        public IndexModel()
        {
            Top7PostNew = new List<PostModel>();
            Top9PostByCate= new List<PostModel>();
        }
        public List<PostModel> Top7PostNew{ get; set; }
        public List<PostModel> Top9PostByCate{ get; set; }
    }
}
