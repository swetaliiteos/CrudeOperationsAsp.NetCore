using CrudOperationsInNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrudOperationsInNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;
        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands()
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brands>> GetBrand1(int id)
        {
           if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            return brand;
        }
        [HttpPost]
        public async Task<ActionResult<Brands>>PostBrand(Brands brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrand1), new { id = brand.brandId }, brand);
        }

        [HttpPut]
        public async Task<IActionResult>PutBrand(int id,Brands brand)
            {
            if(id !=brand.brandId)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BrandAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
            return Ok();
        }
        private bool BrandAvailable(int id)
        {
            return (_dbContext.Brands?.Any(x => x.brandId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrand(int id)
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
         }
        [HttpGet("{brandId}/ModelInfo")]
        public IEnumerable<BrandInformation> GetBrands2()
        {
            var query = from b in _dbContext.Brands
                        join bds in _dbContext.BrandDescription on b.brandId equals bds.BrandDesId
                        join bm in _dbContext.ModelInfo on bds.BrandDesId equals bm.ModelId
                        select new BrandInformation()
                        {
                            brandId = b.brandId,
                            Name = b.Name,
                            Price = b.Price,
                            ModelName = bm.ModelName,
                         ModelId=bm.ModelId,
                         BrandDetails=bds.BrandDetails,
                         BrandDesId=bds.BrandDesId
                         
                        };
            return query.ToList();
        }
        [HttpGet("{ModelId}/BrandDescription")]
        public IEnumerable<BrandInformation> GetBrands3()
        {
            var query = from b in _dbContext.Brands 
                        join m in _dbContext.ModelInfo on b.brandId equals m.brandId
                        join d in _dbContext.BrandDescription on m.ModelId equals d.ModelId
                         select new BrandInformation()
                        {
                             brandId = b.brandId,
                             Name = b.Name,
                             Price = b.Price,
                             ModelId = b.ModelId,
                             ModelName = m.ModelName,
                             BrandDesId = b.BrandDesId,
                             BrandDetails=d.BrandDetails,
                         
                           
                        };
            return query.ToList();
        }
    }
   
}



