namespace SkincareGuide.Web.Controllers
{
    using System;
    using System.IO;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using SkincareGuide.Services.Data;
    using SkincareGuide.Web.ViewModels.Products;

    public class ProductsController : Controller
    {
        private IProductsService productsService;
        private IWebHostEnvironment hostEnvironment;

        public ProductsController(
            IProductsService productsService,
            IWebHostEnvironment hostEnvironment)
        {
            this.productsService = productsService;
            this.hostEnvironment = hostEnvironment;
        }

        [Authorize]

        public IActionResult Create()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = new CreateProductInputModel();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            // save image to wwwroot/products
            string wwwRootPath = this.hostEnvironment.WebRootPath;
            string path = $"{wwwRootPath}/images/products/";

            await this.productsService.CreateAsync(input, userId, path);

            return this.RedirectToAction("Pending");

            // return this.Json(path);
        }

        public IActionResult Pending()
        {
            return this.View();
        }

        public IActionResult AllProducts(int id = 1)
        {
            if (id < 1)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 4;

            var viewModel = new ProductsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ProductsCount = this.productsService.GetCount(),
                Products = this.productsService.GetAll<ProductInListViewModel>(id, itemsPerPage),
            };

            if (id > viewModel.PagesCount)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Image()
        {
            return this.PhysicalFile(this.hostEnvironment.WebRootPath + "/images/products/d4acc91e-72f4-4943-88fe-4eecb2635c39.jpg", "image/jpg");
        }
    }
}
