using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Antivirus.DataSourceAccess.DbModel
{
    public class Signature
    {
        [Key] public int SignatureId { get; set; }

        [Required] public string ActualSignature { get; set; }

        [Required] public string SignatureName { get; set; }

        public ICollection<Virus> Viruses { get; set; }
        
        public Signature()
        {
            Viruses = new List<Virus>();
        }
    }
}