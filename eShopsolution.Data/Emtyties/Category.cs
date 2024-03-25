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
        public string IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public  string Status { set; get; }


        //public List<CategoryTranslation> CategoryTranslations { get; set; }
        //public List<ProductInCategory> ProductInCategories { get; internal set; }
    }
}