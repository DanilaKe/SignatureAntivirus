using Microsoft.EntityFrameworkCore;

namespace Antivirus.DataSourceAccess.DbModel
{
    public class AntivirusContext : DbContext
    {
        public DbSet<Virus> Viruses { get; set; }
        
        public DbSet<Signature> Signatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/media/danila/DISK1/code/Antivirus/Antivirus.DataSourceAccess/Antivirus.db");
        }
    }
}