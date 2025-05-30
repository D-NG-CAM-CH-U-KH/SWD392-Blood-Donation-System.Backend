﻿using System.Linq.Expressions;
using SWD392_BloodDonationSystem.DAL.Data.Metadatas;
using SWD392_BloodDonationSystem.DAL.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SWD392_BloodDonationSystem.DAL.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private DbContext _dbContext;
    private DbSet<TEntity> _dbSet;
    
    public GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    #region Get Async
    
    public virtual async Task<TEntity> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<TResult> FirstOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector, 
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.Select(selector).FirstOrDefaultAsync();
    }

    public virtual async Task<ICollection<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int? take = null,
        int? skip = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        if(take.HasValue) query = query.Take(take.Value);
        if(skip.HasValue) query = query.Skip(skip.Value);
        
        return await query.ToListAsync();
    }

    public virtual async Task<ICollection<TResult>> GetListAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector, 
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int? take = null,
        int? skip = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        if(take.HasValue) query = query.Take(take.Value);
        if(skip.HasValue) query = query.Skip(skip.Value);
        
        return await query.Select(selector).ToListAsync();
    }

    public virtual async Task<PagingResponse<TEntity>> GetPagingListAsync(
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int pageIndex = 1,
        int pageSize = 10,
        int firstPage = 1)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.ToPagingResponseAsync(pageIndex, pageSize, firstPage);
    }

    public virtual async Task<PagingResponse<TResult>> GetPagingListAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector, 
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        int pageIndex = 1, 
        int pageSize = 10,
        int firstPage = 1)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.Select(selector).ToPagingResponseAsync(pageIndex, pageSize, firstPage);
    }

    public virtual async Task<TEntity> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.SingleOrDefaultAsync();
    }

    public virtual async Task<TResult> SingleOrDefaultAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector, 
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        
        return await query.Select(selector).SingleOrDefaultAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        return predicate != null ? _dbSet.CountAsync(predicate) : _dbSet.CountAsync();
    }

    #endregion

    #region Insert Async

    public virtual async Task InsertAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbSet.AddAsync(entity);
    }
    
    public async Task<bool> InsertAsyncSuccessfully(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbSet.AddAsync(entity);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    #endregion

    #region Update

    public virtual void UpdateAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbSet.Update(entity);
    }

    public virtual void UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    #endregion

    #region Delete 

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    #endregion
    
    public IQueryable<TEntity> CreateBaseQuery(
        Expression<Func<TEntity, bool>> predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool asNoTracking = true)
    {
        IQueryable<TEntity> query = _dbSet;
        if(predicate != null) query = query.Where(predicate);
        if(include != null) query = include(query);
        if(orderBy != null) query = orderBy(query);
        if(asNoTracking) query = query.AsNoTracking();

        return query;
    }
}