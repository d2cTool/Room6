using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Services.PlayerRating.Models.DAL;

public class Repository<TModel>:IRepository<TModel> where TModel: class
{
    private readonly DbContext _dbSet;

    public Repository(DbContext dbSet)
    {
        _dbSet = dbSet;
    }

    public IQueryable<TModel> Query()
    {
        return _dbSet.Set<TModel>();
    }

    public async Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate, CancellationToken token = default)
    {
        return await _dbSet.Set<TModel>().FirstOrDefaultAsync(predicate, token);
    }

    public void Insert(TModel model)
    {
        _dbSet.Add(model);
    }
}