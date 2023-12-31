﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafebytesInterfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<T> GetRepo<T>() where T : class, new();
        Task CompleteAsync();
        void Dispose();
    }
}
