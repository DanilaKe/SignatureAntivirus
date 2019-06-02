using System;
using System.Collections.Generic;
using Antivirus.DataSourceAccess.DbModel;

namespace Antivirus.DataSourceAccess.Repository
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        AntivirusContext db { get; set; }
        IEnumerable<T> GetList(); 
        T Get(int id); 
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save(); 
    }
}