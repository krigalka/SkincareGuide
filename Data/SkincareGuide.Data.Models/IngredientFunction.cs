using SkincareGuide.Data.Common.Models;

namespace SkincareGuide.Data.Models
{
    public class IngredientFunction : BaseDeletableModel<int>
    {
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public int FunctionId { get; set; }

        public virtual Function Function { get; set; }
    }
}
