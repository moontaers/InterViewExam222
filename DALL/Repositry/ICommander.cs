using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Repositry
{
    interface ICommander<T> where T : class
    {
        Task AddNewUser(T t);
         Task<T> GetById(int id);
        Task<T> GetById(Expression<Func<T, bool>> expression);

        Task<bool> UpdatePassword(T t);
        Task<IEnumerable<T>> Getby(Expression<Func<T, bool>> expression);
    }

}
