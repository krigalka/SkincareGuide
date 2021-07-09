namespace SkincareGuide.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SkincareGuide.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Functions = new HashSet<IngredientFunction>();
            this.Products = new HashSet<ProductIngredient>();
        }

        [Required]

        public string Name { get; set; }

        public string Aliase { get; set; }

        public string ChemicalName { get; set; }

        public string Tag { get; set; }

        [Required]

        public string Description { get; set; }

        public int? Irritancy { get; set; }

        public int? Comedogenicity { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<IngredientFunction> Functions { get; set; }

        public virtual ICollection<ProductIngredient> Products { get; set; }
    }
}
