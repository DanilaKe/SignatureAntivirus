using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antivirus.DataSourceAccess;
using Antivirus.DataSourceAccess.DbModel;
using Antivirus.DataSourceAccess.Repository;

namespace Antivirus.Scanner.Service
{
    public static class ScannerService
    {
        private static IEnumerable<Signature> _signatures;
        
        public static IDictionary<string, bool> Scan(string path)
        {
            _signatures = UnitOfWork.GetInstance.Signatures.GetList();
            var files = Directory.GetFiles(path,  "*.*", System.IO.SearchOption.AllDirectories);
            return files.ToDictionary(file => file, file => IsVirus(file));
        }

        private static bool IsVirus(string file)
        {
            var actualResult = false;
            using (var sr = new StreamReader(file, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var a = _signatures;
                    foreach (var signature in _signatures)
                    {
                        if (line.Contains(signature.ActualSignature))
                        {
                            UnitOfWork.GetInstance.Viruses.Create(new Virus()
                            {
                                SignatureId = signature.SignatureId,
                                Signature = signature,
                                FilePath = file
                            });
                            UnitOfWork.GetInstance.Save();
                            return true;
                        }   
                    }
                }

                return false;
            }
        }
    }
}