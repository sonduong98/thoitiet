using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Categories
{
    public class CategoryModel :BaseModel
    {
        public string KeyName { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SlugUrl { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int OrderBy { get; set; }
        public string Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int TotalPost { get; set; }
        public string Image { get; set; }
       
    }
}
