using System;
using System.Collections.Generic;

namespace CrudOperationsInNetCore.Repositories
{
    public class ProductRepository:IProductRepository

    {
       protected BrandContext_context;
            public ProductRepository(BrandContext context)
        {
            _context = context;
        }
        public Brand GetBrand(int Id)
        {
            return _context.Brands.AsNoTracking().FirstOrDefault(b =>.BrandId == Id);

        }
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.AsNoTracking().ToList();
        }
            public void AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();

        }
        public void DeleteBrand(Brand brand)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }
		public void UpdateBrand(Brand brand)
		{
            _context.Entry(brand).State = EntityState.Modified;
			_context.SaveChanges();
		}
		//public IEnumerable<BrandInformation> GetBrands2()
		//{
			//var brandList = (from b in _context.Brands
                          //  join bm in _context.ModelInfo on b.ModelId equals pm,ModelId
                           // join  bd in _context.BrandDescription on b.BrandId eqals bd.BrandId
                            //select new BrandInformation()
                            //{
                            //    BrandId = b.BrandId,
                            //    BrandName =b.Brandname,
                            //    Price = b.Price,
                            //    ModelName = bm.ModelName,
                            //    BrandDetails = bd.Branddetails
                           // }).ToList();
           // return brandList;
		//}
	}

    }
}
