namespace SkincareGuide.Services.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SkincareGuide.Data.Common.Repositories;
    using SkincareGuide.Data.Models;
    using SkincareGuide.Services.Mapping;

    public class BrandsService : IBrandsService
    {
        private IDeletableEntityRepository<Brand> brandsRepository;

        public BrandsService(IDeletableEntityRepository<Brand> brandsRepository)
        {
            this.brandsRepository = brandsRepository;

        }


        public IEnumerable<T> GetAll<T>()
        {
            var brands = this.brandsRepository
                 .AllAsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .To<T>()
                 .ToList();
            return brands;
        }
    }
}
