namespace SkincareGuide.Web.ViewModels.Products
{
    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class ItemProductIngredientViewModel : IMapFrom<ProductIngredient>
    {
        public string IngredientName { get; set; }

        public string Function { get; set; }

        public int Irritancy { get; set; }

        public int Comedogenicity { get; set; }

        public string Rating { get; set; }

        // TODO new Column in Ingredient Model-string Rating
    }
}
