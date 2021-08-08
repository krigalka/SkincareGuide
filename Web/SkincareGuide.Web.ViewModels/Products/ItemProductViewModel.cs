namespace SkincareGuide.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;

    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class ItemProductViewModel : IMapFrom<Product>
    {

        public Image Image { get; set; }

        public string BrandName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UploadedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<ItemProductIngredientViewModel> Ingredients { get; set; }
    }
}
