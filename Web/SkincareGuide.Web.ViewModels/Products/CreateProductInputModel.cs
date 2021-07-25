namespace SkincareGuide.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateProductInputModel
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Ingredients { get; set; }

       // public virtual Image Image { get; set; }
    }
}
