using System;
using System.Collections.Generic;
using System.Text;

namespace SkincareGuide.Data.Models
{
    public class User : ApplicationUser
    {
        public User()
        {
            this.UserUploadedProducts = new HashSet<Product>();
        }

        public string Name { get; set; }

        public virtual IEnumerable<Product> UserUploadedProducts { get; set; }
    }
}
