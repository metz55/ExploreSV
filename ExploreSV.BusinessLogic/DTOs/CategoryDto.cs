using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateCategoryRequest
    {

        public string CategoryName { get; set; } = null!;
    }

    public class CategoryResponse
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
