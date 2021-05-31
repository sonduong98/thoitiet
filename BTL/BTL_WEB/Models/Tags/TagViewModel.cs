using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tags
{
    public class TagViewModel : BaseViewModel
    {
        public TagViewModel()
        {
            ListTags = new List<TagModel>();
            InfoTag = new TagModel();
        }
        public List<TagModel> ListTags { get; set; }
        public TagModel InfoTag { get; set; }
    }
}
