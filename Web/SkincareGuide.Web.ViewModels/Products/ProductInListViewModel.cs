namespace SkincareGuide.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class ProductInListViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string ImageId { get; set; }

        public string ImageExtension { get; set; }

        public string Name { get; set; }

        public string BrandName { get; set; }

        public string UploadedByUserEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMapping(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductInListViewModel>();
        }
    }
}
