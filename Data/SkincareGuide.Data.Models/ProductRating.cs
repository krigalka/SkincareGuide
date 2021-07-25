namespace SkincareGuide.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using SkincareGuide.Data.Common.Models;

    public class ProductRating : BaseDeletableModel<int>
    {
        public int Rating { get; set; }

        [ForeignKey(nameof(Product))]

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
