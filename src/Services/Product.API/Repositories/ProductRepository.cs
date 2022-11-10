using Contracts.Common.Interface;
using Infrastructures.Common;
using Microsoft.EntityFrameworkCore;
using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repositories.Interface;

namespace Product.API.Repositories
{
    public class ProductRepository : RepositoryBaseAsync<CatalogProduct, long, ProductContext>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext, IUnitOfWork<ProductContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task CreateProduct(CatalogProduct product)
        {
            return CreateAsync(product);
        }

        public async Task DeleteProduct(long id)
        {
            var product = await GetProduct(id);
            if (product != null) await DeleteAsync(product);
        }

        public Task<CatalogProduct> GetProduct(long id) => GetByIdAsync(id);

        public Task<CatalogProduct> GetProductByNo(string productNo)
        {
            return FindByCondition(x => x.No.Equals(productNo)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CatalogProduct>> GetProducts()
        {
            return await FindAll().ToListAsync();
        }

        public Task UpdateProduct(CatalogProduct product)
        {
            return UpdateAsync(product);
        }
    }
}
