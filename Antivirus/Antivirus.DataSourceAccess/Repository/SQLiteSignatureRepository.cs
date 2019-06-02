using System;
using System.Collections.Generic;
using Antivirus.DataSourceAccess.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Antivirus.DataSourceAccess.Repository
{
    public class SQLiteSignatureRepository : IRepository<Signature>
    {
        private bool disposed = false;
        
        public SQLiteSignatureRepository(AntivirusContext db)
        {
            this.db = db;
        }

        public AntivirusContext db { get; set; }

        public IEnumerable<Signature> GetList()
        {
            return db.Signatures;
        }

        public Signature Get(int id)
        {
            return db.Signatures.Find(id);
        }

        public void Create(Signature item)
        {
            db.Signatures.Add(item);
        }

        public void Update(Signature item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var account = db.Signatures.Find(id);
            if (account != null)
            {
                db.Signatures.Remove(account);
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