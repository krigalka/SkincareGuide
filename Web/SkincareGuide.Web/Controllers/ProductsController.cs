namespace SkincareGuide.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SkincareGuide.Services.Data;
    using SkincareGuide.Web.ViewModels.Products;
    using System.Threading.Tasks;

    public class ProductsController : Controller
    {
        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]

        public async Task <IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }


            await this.productsService.CreateAsync(input);

            return this.RedirectToAction("Pending");

            // return this.Json(input);
        }

        public IActionResult Pending()
        {
            return this.View();
        }
    }
}
