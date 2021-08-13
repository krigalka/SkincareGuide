namespace SkincareGuide.Web.ViewModels.Brands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class BrandNameViewModel : IMapFrom<Brand>
    {
        public string Name { get; set; }
    }
}
