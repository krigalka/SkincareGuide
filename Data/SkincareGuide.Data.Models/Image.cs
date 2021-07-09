namespace SkincareGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using SkincareGuide.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public string UploadedByUserId { get; set; }

        public ApplicationUser UploadedByUser { get; set; }

        public string Extension { get; set; }

        // The content of the image is in the file system
    }
}
