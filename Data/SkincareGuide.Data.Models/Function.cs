namespace SkincareGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SkincareGuide.Data.Common.Models;

    public class Function : BaseDeletableModel<int>
    {
        public Function()
        {
            this.Ingredients = new HashSet<IngredientFunction>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<IngredientFunction> Ingredients { get; set; }
    }
}
