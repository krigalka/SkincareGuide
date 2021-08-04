namespace SkincareGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using SkincareGuide.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UploadedByUserId { get; set; }

        public ApplicationUser UploadedByUser { get; set; }

        public string Extension { get; set; }

        public string ImageUrl { get; set; }

        // The content of the image is in the file system
    }
}
