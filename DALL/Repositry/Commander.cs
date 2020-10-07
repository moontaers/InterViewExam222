using DALL.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace DALL.Repositry
{
    public class Commander<T> : ICommander<T> where T : class
    {
        protected DbSet<T> entity;
        private readonly MyDbContext db=new MyDbContext();

        #region "ctor"
        public Commander()
        {
           
            entity = db.Set<T>();
        }
        #endregion

        #region "Utilites"
        public async  Task AddNewUser(T t)
        {
            entity.Add(t);
           await db.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await entity.FindAsync(id); 
        }

        

        public async Task<bool> UpdatePassword(T t)
        {

            db.Entry<T>(t).State = EntityState.Modified;
            db.SaveChangesAsync();
            return true;
        }

       

     public async Task<IEnumerable<T>> Getby(Expression<Func<T, bool>> expression)
        {
            return await entity.Where(expression).ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expression)
        {
            return await entity.Where(expression).FirstOrDefaultAsync();
        }

        #endregion
    }

}
