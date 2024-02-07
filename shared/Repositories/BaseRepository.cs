using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using shared.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace shared.Repositories;

public class BaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    // CRUD

    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex){ Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);

            if (entity != null) 
            {
                return entity!;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);

            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _context.SaveChanges();

                return entityToUpdate;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);

            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
