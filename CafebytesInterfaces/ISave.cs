using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafebytesInterfaces
{
    public interface ISave<T> where T : class
    {
        Task CompleteAsync();
    }
}
