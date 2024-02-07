using shared.Entities;
using shared.Repositories;
using System.Diagnostics;

namespace shared.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;
    private readonly ManufactureService _manufacturerService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService, ManufactureService manufacturerService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
        _manufacturerService = manufacturerService;
    }

    public ProductEntity CreateProduct(string title, decimal price, string description, string categoryName, string manufactureName)
    {
        try
        {
            var categoryEntity = _categoryService.CreateCategory(categoryName);
            var manufactureEntity = _manufacturerService.CreateManufacture(manufactureName);

            var productEntity = _productRepository.Create(new ProductEntity
            {
                Title = title,
                Price = price,
                Description = description,
                CategoryId = categoryEntity.Id,
                ManufactureId = manufactureEntity.Id
            });

            if (productEntity != null)
            {
                return productEntity;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ProductEntity GetProductById(int id)
    {
        try
        {
            var productEntity = _productRepository.GetOne(x => x.Id == id);
            if (productEntity != null)
            {
                return productEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        try
        {
            var products = _productRepository.GetAll();
            if (products != null)
            {
                return products;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ProductEntity UpdateProduct(ProductEntity ProductEntity)
    {
        try
        {
            var productEntityToUpdate = _productRepository.Update(x => x.Id == ProductEntity.Id, ProductEntity);
            if (productEntityToUpdate != null)
            {
                return productEntityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteProduct(int id)
    {
        try
        {
            var productEntity = _productRepository.GetOne(x => x.Id == id);
            if (productEntity != null)
            {
                _productRepository.Delete(x => x.Id == id);
                return true;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
