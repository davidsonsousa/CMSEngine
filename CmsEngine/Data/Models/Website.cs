﻿using System.Collections.Generic;

namespace CmsEngine.Data.Models
{
    public class Website : BaseModel
    {
        #region Navigation

        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        #endregion

        public string Name { get; set; }

        public string Description { get; set; }

        public string Culture { get; set; }

        public string UrlFormat { get; set; } = $"{Constants.SiteUrl}/{Constants.Type}/{Constants.Slug}";

        public string DateFormat { get; set; } = "MM/dd/yyyy";

        public string SiteUrl { get; set; }
    }
}