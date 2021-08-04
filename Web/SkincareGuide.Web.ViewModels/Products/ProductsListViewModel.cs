namespace SkincareGuide.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductsListViewModel
    {
        public ProductsListViewModel()
        {
            this.Products = new HashSet<ProductInListViewModel>();
        }

        public IEnumerable<ProductInListViewModel> Products { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.ProductsCount / this.ItemsPerPage);

        public int ItemsPerPage { get; set; }

        public int ProductsCount { get; set; }
    }
}
