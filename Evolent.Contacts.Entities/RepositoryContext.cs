using Evolent.Contacts.Entities.Configuration;
using Evolent.Contacts.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Contacts.Entities
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options)
			: base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ContactConfiguration());
		}
		public DbSet<Contact> Contacts { get; set; }
	}
}
