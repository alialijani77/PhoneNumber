using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.DataLayer.Context
{
	public class PhoneNumberDbContext : DbContext
	{
		#region ctor
		//public PhoneNumberDbContext()
		//{

		//}
		public PhoneNumberDbContext(DbContextOptions<PhoneNumberDbContext> options) : base(options)
		{

		}
		#endregion

		#region DbSet
		public DbSet<PhoneNumber.Domain.Entities.PhoneNumber> phoneNumbers { get; set; }
		#endregion

		//protected override void OnConfiguring(DbContextOptionsBuilder options)
		//{
		//	if (!options.IsConfigured)
		//	{
		//		options.UseSqlServer("Data Source = .; Initial Catalog = PhoneNumberDb; Integrated Security = true; MultipleActiveResultSets=true; TrustServerCertificate=True; Trusted_Connection=True;");
		//	}
		//}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//}
	}
}
