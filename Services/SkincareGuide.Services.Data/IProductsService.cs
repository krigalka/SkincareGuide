namespace SkincareGuide.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SkincareGuide.Data.Models;
    using SkincareGuide.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(CreateProductInputModel input, string userId, string path);

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        public int GetCount();

        public T GetProductItem<T>(string name);
    }
}
