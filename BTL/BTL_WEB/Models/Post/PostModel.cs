using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Models.Post
{
    public class PostModel : BaseModel
    {
        public string SlugUrl { get; set; }
        public string Name { get; set; }
        public Nullable<int> CateId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Contents { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public string StartDate { get; set; }
        public List<string> ListTag { get; set; }
        public string NameCate { get; set; }
        public string UrlCate { get; set; }
    }
}
