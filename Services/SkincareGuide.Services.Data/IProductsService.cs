﻿namespace SkincareGuide.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SkincareGuide.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task CreateAsync(CreateProductInputModel input, string userId);

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        public int GetCount();
    }
}
