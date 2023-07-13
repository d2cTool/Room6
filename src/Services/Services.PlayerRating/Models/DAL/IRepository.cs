using System.Linq.Expressions;

namespace Services.PlayerRating.Models.DAL;

public interface IRepository<TModel>
{ 
    IQueryable<TModel> Query();

    Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate, CancellationToken token = default);

    void Insert(TModel model);
}