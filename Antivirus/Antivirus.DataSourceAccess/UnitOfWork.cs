using System;
using Antivirus.DataSourceAccess.DbModel;
using Antivirus.DataSourceAccess.Repository;

namespace Antivirus.DataSourceAccess
{
    public class UnitOfWork : IDisposable
    {
        private static UnitOfWork _instance;
        private bool disposed = false;
        private AntivirusContext db = new AntivirusContext();
        private IRepository<Signature> _repositorySignature;
        private IRepository<Virus> _repositoryVirus;

        private UnitOfWork()
        {
            _instance = this;
        }

        public static UnitOfWork GetInstance => _instance ?? new UnitOfWork();
        
        public IRepository<Virus> Viruses
        {
            get
            {
                if (_repositoryVirus == null)
                {
                    _repositoryVirus = new SQLiteVirusRepository(db);
                }

                return _repositoryVirus;
            }
        }

        public IRepository<Signature> Signatures
        {
            get
            {
                if (_repositorySignature == null)
                {
                    
                    _repositorySignature = new SQLiteSignatureRepository(db);
                }

                return _repositorySignature;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}