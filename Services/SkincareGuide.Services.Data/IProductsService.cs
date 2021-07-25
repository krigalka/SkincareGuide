namespace SkincareGuide.Services.Data
{
    using System.Threading.Tasks;

    using SkincareGuide.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(CreateProductInputModel input);
    }
}
