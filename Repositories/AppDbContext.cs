using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<Currency>().Property(c => c.Name).IsRequired().HasMaxLength(250);
			modelBuilder.Entity<Currency>().Property(c => c.Sign).IsRequired().HasMaxLength(250);
			modelBuilder.Entity<Currency>().Property(c => c.IsActive).HasDefaultValue(true);


			modelBuilder.Entity<ExchangeRate>().HasOne(eh=>eh.Currency).WithMany().HasForeignKey(eh=>eh.CurrencyId);


		}
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<ExchangeRate> ExchangeRatesHistory { get; set; }

	}
}
