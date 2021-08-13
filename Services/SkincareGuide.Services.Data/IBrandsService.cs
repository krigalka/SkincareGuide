namespace SkincareGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using SkincareGuide.Data.Models;

    public interface IBrandsService
    {

        public IEnumerable<T> GetAll<T>();


    }
}
