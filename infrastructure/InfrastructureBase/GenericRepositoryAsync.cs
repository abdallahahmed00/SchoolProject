using infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InfrastructureBase
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly AppDbContext _Context;
        public GenericRepositoryAsync(AppDbContext context)
        {
            _Context = context;

        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
                await _Context.SaveChangesAsync();
            return entity;  
        }   

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
 await _Context.Set<T>().AddRangeAsync(entities);
            await _Context.SaveChangesAsync();

        }
        public virtual IQueryable<T> GetTableAsTracking()
        {
            return _Context.Set<T>().AsQueryable();

        }

        public virtual IDbContextTransaction BeginTransaction()
        {
            return _Context.Database.BeginTransaction();
        }

        public virtual void Commit()
        {
            _Context.Database.CommitTransaction();
        }

        public virtual async Task DeleteAsync(T entity)
        {
              _Context.Set<T>().Remove(entity);
             await _Context.SaveChangesAsync();
                }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _Context.Entry(entity).State = EntityState.Deleted;
            }
            await _Context.SaveChangesAsync();
        }

        public virtual  async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
                }

        

        public virtual IQueryable<T> GetTableNoTracking()
        {
            return  _Context.Set<T>().AsNoTracking().AsQueryable();
        }

        public virtual void RollBack()
        {
            _Context.Database.RollbackTransaction();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
                }

        public virtual async Task UpdateAsync(T entity)
        {
             _Context.Set<T>().Update(entity);
            await   _Context.SaveChangesAsync();  
         }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _Context.Set<T>().UpdateRange(entities);
            await _Context.SaveChangesAsync();
        }
    }
}
