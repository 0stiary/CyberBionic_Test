using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.net.Models
{
	public class ApplicationContext:DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		public  ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}

}