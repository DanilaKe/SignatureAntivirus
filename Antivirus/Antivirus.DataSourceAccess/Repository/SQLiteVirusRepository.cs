using System;
using System.Collections.Generic;
using Antivirus.DataSourceAccess.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.DataSourceAccess.Repository
{
    public class SQLiteVirusRepository : IRepository<Virus>
    {
        private bool disposed = false;
        
        public SQLiteVirusRepository(AntivirusContext db)
        {
            this.db = db;
        }

        public AntivirusContext db { get; set; }

        public IEnumerable<Virus> GetList()
        {
            return db.Viruses;
        }

        public Virus Get(int id)
        {
            return db.Viruses.Find(id);
        }

        public void Create(Virus item)
        {
            db.Viruses.Add(item);
        }

        public void Update(Virus item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var account = db.Viruses.Find(id);
            if (account != null)
            {
                db.Viruses.Remove(account);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}