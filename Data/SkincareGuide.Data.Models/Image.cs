namespace SkincareGuide.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using SkincareGuide.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UploadedByUserId { get; set; }

        public ApplicationUser UploadedByUser { get; set; }

        public string Extension { get; set; }

        public string ImageUrl { get; set; }

        // The content of the image is in the file system
    }
}
