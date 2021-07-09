namespace SkincareGuide.Data.Models
{
    using System;
    using System.Collections.Generic;

    using SkincareGuide.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Ingredients = new HashSet<ProductIngredient>();
        }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public string Name { get; set; }

        public string UploadedByUserId { get; set; }

        public virtual ApplicationUser UploadedByUser { get; set; } // после ще го вържем с потребител

        public int ProductRatingId { get; set; }

        public virtual ProductRating ProductRating { get; set; }

        public virtual ICollection<ProductIngredient> Ingredients { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
