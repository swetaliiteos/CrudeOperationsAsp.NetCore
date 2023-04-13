using CrudOperationsInNetCore.Models;

namespace CrudOperationsInNetCore.Repositories
{
    public interface IBrandRepository
    {
        Brands GetBrand(int Id);
        IEnumerable<Brands> GetBrands();
        void AddBrand(Brands brand);
        void UpdateBrand(Brands brand);
        void DeleteBrand(Brands brand);
        IEnumerable<BrandInformation> GetBrands2();

    }

}
