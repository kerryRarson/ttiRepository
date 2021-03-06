﻿using System.Collections.Generic;

namespace TTI.DAL.Repository
{
    /// <summary>
    /// Should you ever need to add functionality specific to a single class, extend
    /// the interface. See ICompanyRepository.
    /// </summary>
    public interface IRepository<T>
    {
        T Get(object id);
        void Save(T value);
        void Update(T value);
        void Delete(T value);
        IList<T> GetAll();
    }
}
