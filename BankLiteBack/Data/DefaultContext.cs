using BankLiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLiteBack.Data
{
    public class DefaultContext:DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        public DbSet<Accounts> Accounts { get; set; }//帳戶
        public DbSet<Transactions> Transactions { get; set; }//交易紀錄
        public DbSet<Files> Files { get; set; }//附件檔
        public DbSet<Users> Users { get; set; }//使用者
        public DbSet<AccountTypes> AccountTypes { get; set; }//帳戶類別

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.Entity<Transactions>().Property(t => t.Method).HasConversion<int>();
        }
    }
}
