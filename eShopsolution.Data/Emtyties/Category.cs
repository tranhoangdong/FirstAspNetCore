using eShopsolution.Data.Enums;

using eShopSolution.Data.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public Status  status { set; get; }


        public List<CategoryTranslation> CategoryTranslations { get; set; }
        public object ProductInCategories { get; internal set; }
    }
}