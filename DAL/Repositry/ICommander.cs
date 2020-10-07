using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositry
{
    interface ICommander<T>where T:class
    {
        #region"Utitiles" 
        void AddObj(T entity);
        void UpdateObj(T entity);
        #endregion
    }
}
