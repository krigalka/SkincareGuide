namespace SkincareGuide.Data.Models
{
    using SkincareGuide.Data.Common.Models;

    public class ProductIngredient : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
