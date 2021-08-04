namespace SkincareGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using SkincareGuide.Data.Common.Repositories;
    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;
    using SkincareGuide.Web.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private IDeletableEntityRepository<Product> productsRepository;
        private IDeletableEntityRepository<ProductIngredient> productsIngredientsRepository;
        private IDeletableEntityRepository<Ingredient> ingredientsRepository;
        private IDeletableEntityRepository<Brand> brandsRepository;

        public ProductsService(
            IDeletableEntityRepository<Product> productsRepository,
            IDeletableEntityRepository<ProductIngredient> productsIngredientsRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository,
            IDeletableEntityRepository<Brand> brandsRepository)
        {
            this.productsRepository = productsRepository;
            this.productsIngredientsRepository = productsIngredientsRepository;
            this.ingredientsRepository = ingredientsRepository;
            this.brandsRepository = brandsRepository;
        }

        public async Task CreateAsync(CreateProductInputModel input, string userId, string path)
        {
            var brand = this.brandsRepository.All().FirstOrDefault(x => x.Name == input.Brand);

            if (brand == null)
            {
                brand = new Brand
                {
                    Name = input.Brand,
                };
            }

            string extension = Path.GetExtension(input.Image.FileName).TrimStart('.');

            // TODO: validation attribute for Image extension
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var dbImage = new Image
            {
                UploadedByUserId = userId,
                Extension = extension,
            };

            var physicalPath = $"{path}/{dbImage.Id}.{dbImage.Extension}";

            using (FileStream fs = new FileStream(physicalPath, FileMode.Create))
            {
                await input.Image.CopyToAsync(fs);
            }

            var product = new Product
            {
                Brand = brand,
                ImageId = dbImage.Id,
                Image = dbImage,
                Name = input.Name,
                UploadedByUserId = userId,
                Description = input.Description,
            };

            var ingredients = input.Ingredients.
         Split(",")
         .ToList();

            foreach (var ing in ingredients)
            {
                var ingredient = this.ingredientsRepository.All().FirstOrDefault(x => x.Name == ing);

                if (ingredient == null)
                {
                    ingredient = new Ingredient
                    {
                        Name = ing,
                    };
                }

                product.Ingredients.Add(new ProductIngredient
                {
                    Ingredient = ingredient,
                    Product = product,
                });
            }

            await this.productsRepository.AddAsync(product);

            await this.productsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var products = this.productsRepository.AllAsNoTracking()
                  .OrderByDescending(x => x.Id)
                  .Skip((page - 1) * itemsPerPage)
                  .Take(itemsPerPage)
                  .To<T>()
                  .ToList();

            return products;
        }

        public int GetCount()
        {
            return this.productsRepository.All().Count();
        }
    }
}
