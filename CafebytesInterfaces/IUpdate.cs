using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafebytesInterfaces
{
    public interface IUpdate<T> where T : class
    {
        Task<bool> Update(T entity);



        //-------------- Store Procedure
        //Task<bool> UpdateWithSP(T entity);
    }
}
