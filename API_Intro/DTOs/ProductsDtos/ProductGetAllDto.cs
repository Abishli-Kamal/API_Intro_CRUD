using System.Collections.Generic;

namespace API_Intro.DTOs.ProductsDtos
{
    public class ProductGetAllDto
    {
        public List<ProductListItem> ProductList { get; set; }
        public int TotalCount { get; set; }

        public ProductGetAllDto()
        {
            ProductList = new();
        }
    }
}
