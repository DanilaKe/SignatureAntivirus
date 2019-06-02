using System.ComponentModel.DataAnnotations;

namespace Antivirus.DataSourceAccess.DbModel
{
    public class Virus
    {
        [Key] public int VirusId { get; set; }
        
        public int? SignatureId { get; set; }
        
        [Required] public Signature Signature { get; set; }
        
        [Required] public string FilePath { get; set; }
    }
}