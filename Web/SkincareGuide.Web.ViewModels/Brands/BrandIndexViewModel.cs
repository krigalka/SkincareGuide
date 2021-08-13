namespace SkincareGuide.Web.ViewModels.Brands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class BrandIndexViewModel : IMapFrom<Brand>
    {
        public BrandIndexViewModel()
        {
            this.BrandsNames = new HashSet<BrandNameViewModel>();
        }

        public IEnumerable<BrandNameViewModel> BrandsNames { get; set; }
    }
}
