namespace SkincareGuide.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SkincareGuide.Services.Data;
    using SkincareGuide.Web.ViewModels.Brands;

    public class BrandsController : Controller
    {
        private IBrandsService brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            this.brandsService = brandsService;

        }

        public IActionResult Index()
        {

            BrandIndexViewModel brands = new BrandIndexViewModel
            {
                BrandsNames = this.brandsService.GetAll<BrandNameViewModel>(),
            };

            return this.View(brands);
        }

        public IActionResult BrandProducts()
        {
            return this.View();
        }
    }
}
