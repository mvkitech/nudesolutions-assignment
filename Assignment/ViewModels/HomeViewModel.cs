using System.Collections.Generic;
using Assignment.Core.Domain;

namespace Assignment.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public int SumOfAllLimits { get; set; }

        public string NewItemDesc { get; set; }

        public int NewItemLimit { get; set; }

        public CategoryType NewCategoryType { get; set; }
    }
}
