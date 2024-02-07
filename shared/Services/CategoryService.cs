using shared.Entities;
using shared.Repositories;
using System.Diagnostics;

namespace shared.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    // CRUD

    public CategoryEntity CreateCategory(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = _categoryRepository.Create(new CategoryEntity {CategoryName = categoryName});

                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CategoryEntity GetCategoryByCategoryName(string categoryName)
    {
        try
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == categoryName);
            if (categoryEntity != null)
            {
                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        try
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.Id == id);
            if (categoryEntity != null)
            {
                return categoryEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<CategoryEntity> GetCategories()
    {
        try
        {
            var categories = _categoryRepository.GetAll();
            if (categories != null)
            {
                return categories;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CategoryEntity UpdateCategory(CategoryEntity CategoryEntity)
    {
        try
        {
            var categoryEntityToUpdate = _categoryRepository.Update(x => x.Id == CategoryEntity.Id, CategoryEntity);
            if (categoryEntityToUpdate != null)
            {
                return categoryEntityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.Id == id);
            if (categoryEntity != null)
            {
                _categoryRepository.Delete(x => x.Id == id);
                return true;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
