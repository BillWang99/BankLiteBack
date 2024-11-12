using BankLiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLiteBack.Data
{
    public class DefaultContext:DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
