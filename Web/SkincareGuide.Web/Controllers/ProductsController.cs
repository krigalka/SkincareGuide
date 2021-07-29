namespace SkincareGuide.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkincareGuide.Services.Data;
    using SkincareGuide.Web.ViewModels.Products;

    public class ProductsController : Controller
    {
        private IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {

            this.productsService = productsService;
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

            await this.productsService.CreateAsync(input, userId);

            return this.RedirectToAction("Pending");

            // return this.Json(input);
        }

        public IActionResult Pending()
        {
            return this.View();
        }

        public IActionResult AllProducts(int id = 1)
        {
            if(id<1)
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

            if(id>viewModel.PagesCount)
            {
                return this.NotFound();
            }
            return this.View(viewModel);
        }
    }
}
