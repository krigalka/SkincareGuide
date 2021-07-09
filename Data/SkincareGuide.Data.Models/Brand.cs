namespace SkincareGuide.Data.Models
{
    using System.Collections.Generic;

    using SkincareGuide.Data.Common.Models;

    public class Brand : BaseDeletableModel<int>
    {
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
