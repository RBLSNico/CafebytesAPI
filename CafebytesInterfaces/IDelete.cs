using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafebytesInterfaces
{
    public interface IDelete<T> where T : class
    {
        Task<bool> Delete(int id);



        // ------------ Store Procedures
        //Task<bool> DeleteWithSP(int id);
    }
}
