using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositry
{
    public class Commander<T> : ICommander<T> where T : class
    {
        #region "Utilties"


        //protected readonly DbContext Context;
        public void AddObj(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateObj(T entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
